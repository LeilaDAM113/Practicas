import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Router } from '@angular/router';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { InteractionStatus } from '@azure/msal-browser';
import { filter } from 'rxjs';
import { environment } from '../../environments/environment';
import { Cabecera } from '../../compartido/cabecera/cabecera';
import { Pie } from '../../compartido/pie/pie';

@Component({
  selector: 'app-login',
  imports: [Cabecera, Pie],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login implements OnInit {
  private msal = inject(MsalService);
  private eventosMsal = inject(MsalBroadcastService);
  private router = inject(Router);
  private destroyRef = inject(DestroyRef);

  //true mientras comprobamos si ya había sesión (el botón se desactiva)
  protected comprobando = signal(!environment.datosDePrueba);

  ngOnInit(): void {
    if (environment.datosDePrueba) return;
    this.eventosMsal.inProgress$
      .pipe(filter((estado) => estado === InteractionStatus.None), takeUntilDestroyed(this.destroyRef))
      .subscribe(() => {
        if (this.msal.instance.getAllAccounts().length > 0) {
          this.router.navigate(['/mi-firma']);
        } else {
          this.comprobando.set(false);
        }
      });
  }

  //Botón "Iniciar sesión con Microsoft"
  protected iniciarSesion(): void {
    if (environment.datosDePrueba) {
      this.router.navigate(['/mi-firma']);
      return;
    }
    this.comprobando.set(true);
    this.msal
      .loginRedirect({ scopes: environment.graph.scopes, redirectStartPage: `${window.location.origin}/mi-firma` })
      .subscribe();
  }
}
