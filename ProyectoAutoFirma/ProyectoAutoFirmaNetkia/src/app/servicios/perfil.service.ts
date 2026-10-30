import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../environments/environment';
import { PERFIL_PRUEBA } from '../datos/firma.constantes';
import { PerfilUsuario } from '../datos/firma.modelos';

//Lo que devuelve Microsoft Graph
interface PerfilGraph {
  displayName?: string | null;
  mail?: string | null;
  userPrincipalName?: string | null;
  department?: string | null;
  jobTitle?: string | null;
  companyName?: string | null;
  businessPhones?: string[];
  mobilePhone?: string | null;
}

const CAMPOS_PERFIL =
  'displayName,mail,userPrincipalName,department,jobTitle,companyName,businessPhones,mobilePhone';

@Injectable({ providedIn: 'root' })
export class PerfilService {
  private http = inject(HttpClient);

  private readonly _perfil = signal<PerfilUsuario | null>(null);
  private readonly _grupos = signal<string[]>([]);

  readonly perfil = this._perfil.asReadonly();
  readonly grupos = this._grupos.asReadonly();
  readonly cargando = signal(false);
  readonly error = signal<string | null>(null);

  //Criterio provisional: confirmar con la empresa
  readonly esDeItecan = computed(() => {
    const p = this._perfil();
    if (!p) return false;
    return /itecan/i.test(p.empresa) || p.correo.toLowerCase().endsWith('@itecan.es');
  });

  async cargarPerfil(): Promise<void> {
    if (this._perfil()) return;

    if (environment.datosDePrueba) {
      this._perfil.set(PERFIL_PRUEBA);
      return;
    }

    this.cargando.set(true);
    this.error.set(null);
    try {
      const r = await firstValueFrom(
        this.http.get<PerfilGraph>(`${environment.graph.url}/me`, { params: { $select: CAMPOS_PERFIL } }),
      );
      this._perfil.set({
        nombre: r.displayName ?? '',
        correo: r.mail ?? r.userPrincipalName ?? '',
        departamento: r.department ?? '',
        cargo: r.jobTitle ?? '',
        empresa: r.companyName ?? '',
        telefonoOficina: r.businessPhones?.[0] ?? '',
        movil: r.mobilePhone ?? '',
      });
    } catch (e) {
      console.error('Error leyendo /me en Microsoft Graph', e);
      this.error.set('No hemos podido leer tus datos de Microsoft 365. Recarga la página o contacta con Sistemas.');
    } finally {
      this.cargando.set(false);
    }
  }

  //Grupos del usuario (para enseñar solo sus buzones)
  async cargarGrupos(): Promise<void> {
    if (environment.datosDePrueba || this._grupos().length > 0) return;
    try {
      const r = await firstValueFrom(
        this.http.get<{ value: { id: string }[] }>(`${environment.graph.url}/me/memberOf`, { params: { $select: 'id' } }),
      );
      this._grupos.set(r.value.map((g) => g.id));
    } catch (e) {
      console.error('Error leyendo /me/memberOf en Microsoft Graph', e);
      this.error.set('No hemos podido leer tus grupos de Microsoft 365. Contacta con Sistemas.');
    }
  }

  limpiar(): void {
    this._perfil.set(null);
    this._grupos.set([]);
  }
}
