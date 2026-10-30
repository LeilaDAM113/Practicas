import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PublicClientApplication, InteractionType } from '@azure/msal-browser';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import {
  MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG,
  MsalBroadcastService, MsalGuard, MsalInterceptor, MsalService,
} from '@azure/msal-angular';
import { crearConfigGuard, crearConfigInterceptor, crearInstanciaMsal } from './auth/msal.config';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    { provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true },
    { provide: MSAL_INSTANCE, useFactory: crearInstanciaMsal },
    { provide: MSAL_GUARD_CONFIG, useFactory: crearConfigGuard },
    { provide: MSAL_INTERCEPTOR_CONFIG, useFactory: crearConfigInterceptor },
    MsalService,
    MsalGuard,
    MsalBroadcastService,
  ],
};
