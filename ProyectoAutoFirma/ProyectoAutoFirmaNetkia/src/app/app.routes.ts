import { Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { environment } from './environments/environment';
import { Login } from './paginas/login/login';
import { MiFirma } from './paginas/mi-firma/mi-firma';
import { FirmaDepartamento } from './paginas/firma-departamento/firma-departamento';

//Con el empleado de prueba no hay login, así que no ponemos "portero"
const protegida = environment.datosDePrueba ? [] : [MsalGuard];

export const routes: Routes = [
  { path: '', component: Login, title: 'Netkia Firmas · Iniciar sesión' },
  { path: 'mi-firma', component: MiFirma, canActivate: protegida, title: 'Netkia Firmas · Mi firma' },
  { path: 'departamento', component: FirmaDepartamento, canActivate: protegida, title: 'Netkia Firmas · Firma de departamento' },
  { path: '**', redirectTo: '' },
];
