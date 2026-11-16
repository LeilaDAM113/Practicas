import { Component, OnInit, inject, input, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ApiService } from '../../../servicios/api.service';
import { mensajeError } from '../../../servicios/errores';
import { Aplicacion, ENTORNOS, EXPOSICIONES, Proyecto, TIPOS_TECNOLOGIA } from '../../../datos/inventario.modelos';

const VACIA = {
  nombre: '',
  entorno: 'Prod',
  exposicion: 'Publico',
  tipo_tecnologia: 'Framework',
  url: '',
  framework_nombre: '',
  framework_version: '',
  lenguaje: '',
  lenguaje_version: '',
  gestor_paquetes: '',
  gestor_version: '',
  url_repositorio: '',
};

@Component({
  selector: 'app-detalle-proyecto',
  imports: [ReactiveFormsModule, RouterLink, DatePipe],
  templateUrl: './detalle.html',
})
export class DetalleProyecto implements OnInit {
  private api = inject(ApiService);
  private router = inject(Router);

  id = input.required<string>(); //viene de la ruta id

  protected proyecto = signal<Proyecto | null>(null);
  protected error = signal<string | null>(null);
  protected errorForm = signal<string | null>(null);
  protected mostrarForm = signal(false);
  protected editandoId = signal<number | null>(null);
  protected guardando = signal(false);

  protected entornos = ENTORNOS;
  protected exposiciones = EXPOSICIONES;
  protected tipos = TIPOS_TECNOLOGIA;

  protected form = inject(FormBuilder).nonNullable.group({
    ...VACIA,
    nombre: ['', [Validators.required, Validators.maxLength(150)]],
  });

  ngOnInit(): void {
    this.recargar();
  }

  private recargar(): void {
    this.api.proyecto(+this.id()).subscribe({
      next: (p) => this.proyecto.set(p),
      error: (e) => this.error.set(mensajeError(e)),
    });
  }

  protected nueva(): void {
    this.editandoId.set(null);
    this.form.reset(VACIA);
    this.errorForm.set(null);
    this.mostrarForm.set(true);
  }

  protected editar(a: Aplicacion): void {
    this.editandoId.set(a.id ?? null);
    //null -> '' para que los campos del formulario queden vacíos
    this.form.reset({ ...VACIA, ...Object.fromEntries(Object.entries(a).map(([k, v]) => [k, v ?? ''])) });
    this.errorForm.set(null);
    this.mostrarForm.set(true);
  }

  //Copia una aplicación para dar de alta el mismo módulo en otro entorno
  protected duplicar(a: Aplicacion): void {
    this.editar(a);
    this.editandoId.set(null);
    this.form.patchValue({ entorno: a.entorno === 'Prod' ? 'Test' : a.entorno === 'Test' ? 'Dev' : 'Prod' });
  }

  protected cancelar(): void {
    this.mostrarForm.set(false);
    this.editandoId.set(null);
  }

  protected guardar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.guardando.set(true);
    this.errorForm.set(null);
    //Los campos vacíos se mandan como null
    const datos = Object.fromEntries(
      Object.entries(this.form.getRawValue()).map(([k, v]) => [k, v === '' ? null : v]),
    ) as unknown as Aplicacion;
    const editando = this.editandoId();
    const peticion = editando
      ? this.api.actualizarAplicacion(editando, datos)
      : this.api.crearAplicacion(+this.id(), datos);
    peticion.subscribe({
      next: () => {
        this.guardando.set(false);
        this.cancelar();
        this.recargar();
      },
      error: (e) => {
        this.errorForm.set(mensajeError(e));
        this.guardando.set(false);
      },
    });
  }

  protected borrarAplicacion(a: Aplicacion): void {
    if (!confirm(`¿Borrar "${a.nombre}" (${a.entorno})? También se borrará su historial de análisis.`)) return;
    this.api.borrarAplicacion(a.id!).subscribe({
      next: () => this.recargar(),
      error: (e) => this.error.set(mensajeError(e)),
    });
  }

  protected borrarProyecto(p: Proyecto): void {
    if (!confirm(`¿Borrar el proyecto "${p.nombre}" y sus ${p.aplicaciones.length} aplicaciones?`)) return;
    this.api.borrarProyecto(p.id).subscribe({
      next: () => this.router.navigate(['/proyectos']),
      error: (e) => this.error.set(mensajeError(e)),
    });
  }
}
