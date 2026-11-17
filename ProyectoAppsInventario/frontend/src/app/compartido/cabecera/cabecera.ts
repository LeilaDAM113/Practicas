import { Component, computed, inject, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { environment } from '../../environments/environment';
import { SesionService } from '../../servicios/sesion.service';
import { USUARIOS_PRUEBA, guardarUsuarioPrueba, usuarioPruebaActual } from '../../auth/usuarioPrueba.interceptor';
@Component({
  selector: 'app-cabecera',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './cabecera.html',
  styleUrl: './cabecera.scss',
})
export class Cabecera {
  //true en las pantallas internas (enseña menú, usuario y "Cerrar sesión")
  mostrarUsuario = input(false);

  protected sesion = inject(SesionService);
  protected usuario = this.sesion.usuario;
  protected modoPrueba = environment.datosDePrueba;
  protected usuariosPrueba = USUARIOS_PRUEBA;
  protected usuarioPrueba = usuarioPruebaActual();

  //"Carlos Labrador" -> "CL"
  protected iniciales = computed(() =>
    (this.usuario()?.nombre ?? '')
      .split(' ')
      .filter((p) => p.length > 0)
      .slice(0, 2)
      .map((p) => p[0].toUpperCase())
      .join(''),
  );

  protected rolLegible = computed(() =>
    (this.usuario()?.roles ?? [])
      .map((r) => (r === 'SEGURIDAD_INFORMATICA' ? 'Seguridad Informática' : r === 'PROJECT_MANAGER' ? 'Project Manager' : r))
      .join(' · '),
  );

  //Cambia de usuario de prueba y recarga para empezar limpio
  protected cambiarUsuarioPrueba(evento: Event): void {
    guardarUsuarioPrueba((evento.target as HTMLSelectElement).value);
    location.reload();
  }

  protected cerrarSesion(): void {
    this.sesion.cerrarSesion();
  }
}