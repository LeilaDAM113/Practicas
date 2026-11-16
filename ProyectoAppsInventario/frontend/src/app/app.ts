import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { RouterOutlet } from '@angular/router';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { InteractionStatus } from '@azure/msal-browser';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App implements OnInit {
  private msal = inject(MsalService);
  private eventosMsal = inject(MsalBroadcastService);
  private destroyRef = inject(DestroyRef);

  ngOnInit(): void {
    //Procesa la vuelta desde Microsoft.
    this.msal.handleRedirectObservable().subscribe();

    //Cuando MSAL termina, recordamos qué cuenta ha entrado.
    this.eventosMsal.inProgress$
      .pipe(filter((estado) => estado === InteractionStatus.None), takeUntilDestroyed(this.destroyRef))
      .subscribe(() => {
        const instancia = this.msal.instance;
        const cuentas = instancia.getAllAccounts();
        if (!instancia.getActiveAccount() && cuentas.length > 0) {
          instancia.setActiveAccount(cuentas[0]);
        }
      });
  }
}
