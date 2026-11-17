import { Component, OnInit, computed, inject, input, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ApiService } from '../../servicios/api.service';
import { mensajeError } from '../../servicios/errores';
import { Analisis, Aplicacion, Proyecto } from '../../datos/inventario.modelos';

@Component({
  selector: 'app-analisis',
  imports: [DatePipe, RouterLink],
  templateUrl: './analisis.html',
})
export class AnalisisDependencias implements OnInit {
  private api = inject(ApiService);

  id = input.required<string>(); //id de la aplicación (ruta :id)

  protected aplicacion = signal<Aplicacion | null>(null);
  protected proyecto = signal<Proyecto | null>(null);
  protected historial = signal<Analisis[]>([]);
  protected seleccionado = signal<number | null>(null);
  protected fichero = signal<File | null>(null);
  protected analizando = signal(false);
  protected error = signal<string | null>(null);

  //El análisis que se enseña: el elegido o el último
  protected actual = computed(() => {
    const h = this.historial();
    return h.find((a) => a.id === this.seleccionado()) ?? h[0] ?? null;
  });

  protected resumen = computed(() => {
    const cuenta: Record<string, number> = {};
    for (const h of this.actual()?.hallazgos ?? []) cuenta[h.severidad] = (cuenta[h.severidad] ?? 0) + 1;
    return cuenta;
  });

  protected tieneAproximados = computed(() => (this.actual()?.hallazgos ?? []).some((h) => h.aproximado));

  ngOnInit(): void {
    const id = +this.id();
    this.api.aplicacion(id).subscribe({
      next: (a) => {
        this.aplicacion.set(a);
        this.api.proyecto(a.proyecto_id!).subscribe((p) => this.proyecto.set(p));
      },
      error: (e) => this.error.set(mensajeError(e)),
    });
    this.api.historialAnalisis(id).subscribe((h) => this.historial.set(h));
  }

  protected elegir(evento: Event): void {
    this.fichero.set((evento.target as HTMLInputElement).files?.[0] ?? null);
    this.error.set(null);
  }

  protected analizar(): void {
    const f = this.fichero();
    if (!f) return;
    this.analizando.set(true);
    this.error.set(null);
    this.api.analizar(+this.id(), f).subscribe({
      next: (a) => {
        this.historial.update((h) => [a, ...h]);
        this.seleccionado.set(a.id);
        this.analizando.set(false);
      },
      error: (e) => {
        this.error.set(mensajeError(e, 'Error al analizar el fichero.'));
        this.analizando.set(false);
      },
    });
  }
}
