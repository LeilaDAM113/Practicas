import { MsalGuardConfiguration, MsalInterceptorConfiguration } from '@azure/msal-angular';
import { BrowserCacheLocation, InteractionType, IPublicClientApplication, PublicClientApplication } from '@azure/msal-browser';
import { environment } from '../environments/environment';

//Quién soy para Microsoft
export function crearInstanciaMsal(): PublicClientApplication {
  return new PublicClientApplication({
    auth: {
      clientId: environment.msal.clientId,
      authority: `https://login.microsoftonline.com/${environment.msal.tenantId}`,
      redirectUri: 'http://localhost:4200/auth/login',
      postLogoutRedirectUri: '/',
    },
    cache: { cacheLocation: BrowserCacheLocation.SessionStorage },
  });
}

//Configuración de un guardia de navegación de MSAL
export function crearConfigGuard(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
    authRequest: { scopes: environment.graph.scopes },
    loginFailedRoute: '/',
  };
}

///A qué direcciones hay que enviar el token
export function crearConfigInterceptor(): MsalInterceptorConfiguration {
  const recursosProtegidos = new Map<string, string[]>();
  recursosProtegidos.set('https://graph.microsoft.com/v1.0/*', environment.graph.scopes);
  return { interactionType: InteractionType.Redirect, protectedResourceMap: recursosProtegidos, strictMatching: true };
}
