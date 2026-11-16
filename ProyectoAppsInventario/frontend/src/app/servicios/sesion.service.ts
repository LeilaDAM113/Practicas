import { Injectable, computed, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { firstValueFrom } from 'rxjs';
import { environment } from '../environments/environment';
import { ApiService } from './api.service';
import { Usuario } from '../datos/inventario.modelos';

//el usuario y sus roles vienen de NUESTRA API (/api/me)
@Injectable({ providedIn: 'root' })
export class SesionService {
  private msal = inject(MsalService);
  private api = inject(ApiService);
  private router = inject(Router);

  private readonly _usuario = signal<Usuario | null>(null);
  readonly usuario = this._usuario.asReadonly();
  readonly error = signal<string | null>(null);

  readonly esSeguridad = computed(() => this._usuario()?.roles.includes('SEGURIDAD_INFORMATICA') ?? false);
  readonly esPM = computed(() => this._usuario()?.roles.includes('PROJECT_MANAGER') ?? false);

  async cargar(forzar = false): Promise<void> {
    if (this._usuario() && !forzar) return;
    if (!environment.datosDePrueba && this.msal.instance.getAllAccounts().length === 0) return;
    try {
      this._usuario.set(await firstValueFrom(this.api.me()));
      this.error.set(null);
    } catch {
      this.error.set('No tienes acceso a esta herramienta o no tienes ningún rol asignado. Contacta con Sistemas.');
    }
  }

  cerrarSesion(): void {
    this._usuario.set(null);
    if (environment.datosDePrueba) {
      this.router.navigate(['/']);
      return;
    }
    this.msal.logoutRedirect().subscribe();
  }
}
