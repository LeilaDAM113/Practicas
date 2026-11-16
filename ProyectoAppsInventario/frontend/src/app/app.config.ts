import { ApplicationConfig, LOCALE_ID, provideBrowserGlobalErrorListeners } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import {
  HTTP_INTERCEPTORS, provideHttpClient, withInterceptors, withInterceptorsFromDi,
} from '@angular/common/http';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import {
  MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG,
  MsalBroadcastService, MsalGuard, MsalInterceptor, MsalService,
} from '@azure/msal-angular';
import { routes } from './app.routes';
import { environment } from './environments/environment';
import { crearConfigGuard, crearConfigInterceptor, crearInstanciaMsal } from './auth/msal.config';
import { usuarioPruebaInterceptor } from './auth/usuarioPrueba.interceptor';

registerLocaleData(localeEs);

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
   { provide: LOCALE_ID, useValue: 'es' },
    provideRouter(routes,  withComponentInputBinding()),  //id de la ruta -> input() del componente
    provideHttpClient(withInterceptorsFromDi(), withInterceptors([usuarioPruebaInterceptor])),
    ...(environment.datosDePrueba
      ? []
      : [{ provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true }]),
    { provide: MSAL_INSTANCE, useFactory: crearInstanciaMsal },
    { provide: MSAL_GUARD_CONFIG, useFactory: crearConfigGuard },
    { provide: MSAL_INTERCEPTOR_CONFIG, useFactory: crearConfigInterceptor },
    MsalService,
    MsalGuard,
    MsalBroadcastService,
  ],
};
