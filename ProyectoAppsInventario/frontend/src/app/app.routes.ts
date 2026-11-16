import { Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { environment } from './environments/environment';
import { Login } from './paginas/login/login';
import { Marco } from './compartido/marco/marco';

const protegida = environment.datosDePrueba ? [] : [MsalGuard];

export const routes: Routes = [
  { path: '', pathMatch: 'full', component: Login, title: 'Netkia Inventario Aplicaciones'},
  {
    path: '',
    component: Marco,
    canActivate: protegida,
    children: [
      {
        path: 'proyectos',
        title: 'Inventario · Proyectos',
        loadComponent: () => import('./paginas/proyectos/lista/lista').then((m) => m.ListaProyectos),
      },
      {
        path: 'proyectos/nuevo',
        title: 'Inventario · Nuevo proyecto',
        loadComponent: () => import('./paginas/proyectos/formulario/formulario').then((m) => m.FormularioProyecto),
      },
      {
        path: 'proyectos/:id/editar',
        title: 'Inventario · Editar proyecto',
        loadComponent: () => import('./paginas/proyectos/formulario/formulario').then((m) => m.FormularioProyecto),
      },
      {
        path: 'proyectos/:id',
        title: 'Inventario · Proyecto',
        loadComponent: () => import('./paginas/proyectos/detalle/detalle').then((m) => m.DetalleProyecto),
      },
      {
        path: 'buscar',
        title: 'Inventario · Buscar tecnología',
        loadComponent: () => import('./paginas/buscar/buscar').then((m) => m.Buscar),
      },
      {
        path: 'aplicaciones/:id/analisis',
        title: 'Inventario · Dependencias',
        loadComponent: () => import('./paginas/analisis/analisis').then((m) => m.Analisis),
      },
    ],
  },
  { path: '**', redirectTo: '' },
];
