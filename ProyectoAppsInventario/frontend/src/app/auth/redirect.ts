import { Component, OnInit } from '@angular/core';
import { broadcastResponseToMainFrame } from '@azure/msal-browser/redirect-bridge';

// /redirect: recoge la respuesta de Microsoft y vuelve a la app
@Component({
  selector: 'app-root',
  template: '<p style="font-family: Poppins, sans-serif; padding: 24px">Procesando inicio de sesión…</p>',
})
export class Redirect implements OnInit {
  ngOnInit(): void {
    broadcastResponseToMainFrame().catch((error: Error) => console.error('Error procesando la respuesta de Microsoft:', error));
  }
}
