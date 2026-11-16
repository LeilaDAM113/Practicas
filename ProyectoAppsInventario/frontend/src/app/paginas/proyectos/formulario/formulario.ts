import { Component, OnInit, inject, input, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ApiService } from '../../../servicios/api.service';
import { mensajeError } from '../../../servicios/errores';

//Sirve para crear (/proyectos/nuevo) y para editar (/proyectos/:id/editar)
@Component({
  selector: 'app-formulario-proyecto',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './formulario.html',
})
export class FormularioProyecto implements OnInit {
  private api = inject(ApiService);
  private router = inject(Router);

  id = input<string>(); //viene de la ruta (solo al editar)

  protected guardando = signal(false);
  protected error = signal<string | null>(null);

  protected form = inject(FormBuilder).nonNullable.group({
    nombre: ['', [Validators.required, Validators.maxLength(150)]],
    cliente: ['', [Validators.required, Validators.maxLength(150)]],
    responsable: ['', [Validators.required, Validators.maxLength(150)]],
    mantenimiento_contratado: [false],
  });

  ngOnInit(): void {
    const id = this.id();
    if (!id) return;
    this.api.proyecto(+id).subscribe({
      next: (p) => {
        if (!p.puede_editar) {
          this.router.navigate(['/proyectos', p.id]);
          return;
        }
        this.form.patchValue(p);
      },
      error: (e) => this.error.set(mensajeError(e)),
    });
  }

  protected guardar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.guardando.set(true);
    this.error.set(null);
    const datos = this.form.getRawValue();
    const id = this.id();
    const peticion = id ? this.api.actualizarProyecto(+id, datos) : this.api.crearProyecto(datos);
    peticion.subscribe({
      next: (p) => this.router.navigate(['/proyectos', p.id]),
      error: (e) => {
        this.error.set(mensajeError(e));
        this.guardando.set(false);
      },
    });
  }
}
