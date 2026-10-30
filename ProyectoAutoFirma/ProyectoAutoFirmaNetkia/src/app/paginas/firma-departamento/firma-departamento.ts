import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { environment } from '../../environments/environment';
import { Cabecera } from '../../compartido/cabecera/cabecera';
import { GuiaInstalacion } from '../../compartido/guia-instalacion/guia-instalacion';
import { Pie } from '../../compartido/pie/pie';
import { SelectorIconos } from '../../compartido/selector-iconos/selector-iconos';
import { SelectorModo } from '../../compartido/selector-modo/selector-modo';
import { VistaPrevia } from '../../compartido/vista-previa/vista-previa';
import { BUZONES } from '../../datos/firma.constantes';
import { Buzon, DatosFirma } from '../../datos/firma.modelos';
import { FirmaService } from '../../servicios/firma.service';
import { PerfilService } from '../../servicios/perfil.service';

@Component({
  selector: 'app-firma-departamento',
  imports: [FormsModule, Cabecera, Pie, SelectorModo, SelectorIconos, VistaPrevia, GuiaInstalacion],
  templateUrl: './firma-departamento.html',
  styleUrl: './firma-departamento.css',
})
export class FirmaDepartamento implements OnInit {
  protected perfilService = inject(PerfilService);
  protected firma = inject(FirmaService);

  protected buzonId = signal<string | null>(null);
  protected nombre = signal('');
  protected linea = signal('');
  protected telefono = signal('');
  protected iconoElegido = signal<string | null>(null);

  //Solo los buzones de los grupos del usuario (o todos, en pruebas)
  protected buzonesDisponibles = computed<Buzon[]>(() => {
    if (environment.datosDePrueba || environment.mostrarTodosLosBuzones) return BUZONES;
    const grupos = this.perfilService.grupos();
    return BUZONES.filter((b) => grupos.includes(b.grupoId));
  });

  protected buzon = computed<Buzon | null>(() => this.buzonesDisponibles().find((b) => b.id === this.buzonId()) ?? null);

  protected iconoActual = computed(() => this.iconoElegido() ?? this.buzon()?.icono ?? 'comunicados');

  protected datos = computed<DatosFirma | null>(() => {
    const b = this.buzon();
    if (!b) return null;
    return {
      nombre: this.nombre().trim(),
      linea: this.linea().trim(),
      correo: b.correo,
      telefonos: this.telefono().trim(),
      icono: this.firma.iconoPorId(this.iconoActual()),
      nota: '',
      nombreArchivo: this.firma.nombreArchivo(b.id),
    };
  });

  async ngOnInit(): Promise<void> {
    await Promise.all([this.perfilService.cargarPerfil(), this.perfilService.cargarGrupos()]);
    const primero = this.buzonesDisponibles()[0];
    if (primero) this.elegirBuzon(primero);
  }

  //Al pulsar un buzón de la lista
  protected elegirBuzon(b: Buzon): void {
    this.buzonId.set(b.id);
    this.nombre.set(b.nombre);
    this.linea.set(b.linea);
    this.telefono.set(b.telefono);
    this.iconoElegido.set(null);
  }

  //Botón "Restaurar valores"
  protected restaurar(): void {
    const b = this.buzon();
    if (b) this.elegirBuzon(b);
  }
}
