import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Cabecera } from '../cabecera/cabecera';
import { Pie } from '../pie/pie';
import { SesionService } from '../../servicios/sesion.service';

//Estructura común de las pantallas internas: cabecera + contenido + pie
@Component({
  selector: 'app-marco',
  imports: [RouterOutlet, Cabecera, Pie],
  template: `
    <div class="marco">
      <app-cabecera [mostrarUsuario]="true" />
      <main class="marco__main">
        <div class="contenedor">
          @if (sesion.error(); as e) {
            <p class="aviso-error">{{ e }}</p>
          } @else if (sesion.usuario()) {
            <router-outlet />
          } @else {
            <p class="cargando">Cargando…</p>
          }
        </div>
      </main>
      <app-pie />
    </div>
  `,
  styles: `
    .marco { min-height: 100vh; display: flex; flex-direction: column; }
    .marco__main { flex: 1 0 auto; background: linear-gradient(180deg, #ffffff 0%, var(--nk-fondo-azul) 240px); padding: 40px 0 80px; }
  `,
})
export class Marco {
  protected sesion = inject(SesionService);

  constructor() {
    this.sesion.cargar();
  }
}
