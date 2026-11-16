import { Component, computed, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ApiService } from '../../../servicios/api.service';
import { SesionService } from '../../../servicios/sesion.service';
import { mensajeError } from '../../../servicios/errores';
import { Proyecto } from '../../../datos/inventario.modelos';

@Component({
  selector: 'app-lista-proyectos',
  imports: [FormsModule, RouterLink],
  templateUrl: './lista.html',
})
export class ListaProyectos {
  private api = inject(ApiService);
  protected sesion = inject(SesionService);

  protected proyectos = signal<Proyecto[]>([]);
  protected cargando = signal(true);
  protected error = signal<string | null>(null);
  protected filtro = signal('');

  protected visibles = computed(() => {
    const f = this.filtro().trim().toLowerCase();
    if (!f) return this.proyectos();
    return this.proyectos().filter((p) =>
      [p.nombre, p.cliente, p.responsable, p.creado_por_nombre].some((t) => t.toLowerCase().includes(f)),
    );
  });

  protected totalApps = computed(() => this.proyectos().reduce((n, p) => n + p.aplicaciones.length, 0));
  protected publicasEnProd = computed(
    () =>
      this.proyectos()
        .flatMap((p) => p.aplicaciones)
        .filter((a) => a.entorno === 'Prod' && a.exposicion === 'Publico').length,
  );

  constructor() {
    this.api.proyectos().subscribe({
      next: (p) => {
        this.proyectos.set(p);
        this.cargando.set(false);
      },
      error: (e) => {
        this.error.set(mensajeError(e));
        this.cargando.set(false);
      },
    });
  }
}
