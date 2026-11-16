import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ApiService } from '../../servicios/api.service';
import { SesionService } from '../../servicios/sesion.service';
import { mensajeError } from '../../servicios/errores';
import { ENTORNOS, EXPOSICIONES, ResultadoBusqueda, TIPOS_TECNOLOGIA } from '../../datos/inventario.modelos';

@Component({
  selector: 'app-buscar',
  imports: [FormsModule, RouterLink],
  templateUrl: './buscar.html',
})
export class Buscar {
  private api = inject(ApiService);
  protected sesion = inject(SesionService);

  protected entornos = ENTORNOS;
  protected exposiciones = EXPOSICIONES;
  protected tipos = TIPOS_TECNOLOGIA;

  protected f = { q: '', version_menor_que: '', entorno: '', exposicion: '', tipo_tecnologia: '' };
  protected resultados = signal<ResultadoBusqueda[]>([]);
  protected buscado = signal(false);
  protected cargando = signal(false);
  protected error = signal<string | null>(null);

  constructor() {
    this.buscar(); //al entrar, enseña todo
  }

  protected buscar(): void {
    this.cargando.set(true);
    this.error.set(null);
    this.api.buscar(this.f).subscribe({
      next: (r) => {
        this.resultados.set(r);
        this.buscado.set(true);
        this.cargando.set(false);
      },
      error: (e) => {
        this.error.set(mensajeError(e));
        this.cargando.set(false);
      },
    });
  }

  protected limpiar(): void {
    this.f = { q: '', version_menor_que: '', entorno: '', exposicion: '', tipo_tecnologia: '' };
    this.buscar();
  }

  //Descarga los resultados en CSV (se abre en Excel)
  protected exportarCsv(): void {
    const columnas: [string, (r: ResultadoBusqueda) => string | null][] = [
      ['Proyecto', (r) => r.proyecto_nombre],
      ['Cliente', (r) => r.cliente],
      ['Aplicación/Módulo', (r) => r.nombre],
      ['Entorno', (r) => r.entorno],
      ['URL Aplicación', (r) => r.url],
      ['Exposición', (r) => r.exposicion],
      ['Tipo de Tecnología', (r) => r.tipo_tecnologia],
      ['Framework', (r) => r.framework_nombre],
      ['Versión Framework', (r) => r.framework_version],
      ['Lenguaje', (r) => r.lenguaje],
      ['Versión Lenguaje', (r) => r.lenguaje_version],
      ['Gestor de Paquetes', (r) => r.gestor_paquetes],
      ['Versión Gestor', (r) => r.gestor_version],
      ['Responsable', (r) => r.responsable],
      ['URL Repositorio', (r) => r.url_repositorio],
    ];
    const celda = (v: string | null) => `"${(v ?? '').replace(/"/g, '""')}"`;
    const lineas = [
      columnas.map(([t]) => celda(t)).join(';'),
      ...this.resultados().map((r) => columnas.map(([, fn]) => celda(fn(r))).join(';')),
    ];
    const blob = new Blob(['﻿' + lineas.join('\r\n')], { type: 'text/csv;charset=utf-8' });
    const enlace = document.createElement('a');
    enlace.href = URL.createObjectURL(blob);
    enlace.download = `inventario-aplicaciones-${new Date().toISOString().slice(0, 10)}.csv`;
    enlace.click();
    URL.revokeObjectURL(enlace.href);
  }
}

