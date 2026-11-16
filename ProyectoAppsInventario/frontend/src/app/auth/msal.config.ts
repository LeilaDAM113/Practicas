import { MsalGuardConfiguration, MsalInterceptorConfiguration } from '@azure/msal-angular';
import { BrowserCacheLocation, InteractionType, PublicClientApplication } from '@azure/msal-browser';
import { environment } from '../environments/environment';

//Quién soy para Microsoft
export function crearInstanciaMsal(): PublicClientApplication {
  return new PublicClientApplication({
    auth: {
      clientId: environment.msal.clientId,
      authority: `https://login.microsoftonline.com/${environment.msal.tenantId}`,
      redirectUri: environment.msal.redirectUri,
      postLogoutRedirectUri: '/',
    },
    cache: { cacheLocation: BrowserCacheLocation.SessionStorage },
  });
}

//Guardia de navegación: si no hay sesión, al login de Microsoft
export function crearConfigGuard(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
    authRequest: { scopes: [environment.apiScope] },
    loginFailedRoute: '/',
  };
}

//A qué direcciones hay que enviar el token: a nuestra API
export function crearConfigInterceptor(): MsalInterceptorConfiguration {
  const recursosProtegidos = new Map<string, string[]>();
  recursosProtegidos.set(`${environment.apiUrl}/*`, [environment.apiScope]);
  return { interactionType: InteractionType.Redirect, protectedResourceMap: recursosProtegidos };
}
