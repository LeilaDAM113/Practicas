import { Component, computed, inject, input } from '@angular/core'
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { environment } from '../../environments/environment';
import { PerfilService } from '../../servicios/perfil.service';

type Pagina = 'primera' | 'segunda';
@Component({
  selector: 'app-cabecera',
  templateUrl: './cabecera.html',
  styleUrl: './cabecera.css',
})
export class Cabecera {

  //true en las pantallas 2 y 3 (enseña el usuario y "Cerrar sesión")
  mostrarUsuario = input(false);

  private perfilService = inject(PerfilService);
  private msal = inject(MsalService);
  private router = inject(Router);

  protected perfil = this.perfilService.perfil;
    paginaActiva: Pagina = 'primera';

  //"Nadia Prida Romano" → "NP" 
  protected iniciales = computed(() =>
    (this.perfil()?.nombre ?? '').split(' ').filter((p) => p.length > 0).slice(0, 2).map((p) => p[0].toUpperCase()).join(''),
  );

  //Botón "Cerrar sesión"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
  protected cerrarSesion(): void {
    this.perfilService.limpiar();
    if (environment.datosDePrueba) {
      this.router.navigate(['/']);
      return;
    }
    this.msal.logoutRedirect().subscribe();
  }

  //Para cambiar la etiqueta de "Firmas de correo" a la izquierda o a la derecha segun la página que sea
  cambiarPestana(indice: number): void {
    this.paginaActiva = indice === 1 ? 'segunda' : 'primera';
  }
}
