import { HttpInterceptorFn } from "@angular/common/http";
import { environment } from '../environments/environment';

export const USUARIOS_PRUEBA = [
  { id: 'pm-a', etiqueta: 'PM Prueba A' },
  { id: 'pm-b', etiqueta: 'PM Prueba B' },
  { id: 'seguridad', etiqueta: 'Seguridad Prueba' },
];

export function usuarioPruebaActual(): string {
  try {
    return localStorage.getItem('usuarioPrueba') ?? 'pm-a';
  } catch {
    return 'pm-a';
  }
}

export function guardarUsuarioPrueba(id: string): void {
    try{
      localStorage.setItem('usuarioPrueba', id);  
    }catch{
     /* sin almacenamiento: se queda el de por defecto */   
    }
}

//Añade la cabecera X-Usuario-Prueba a las llamadas a la API (solo en modo prueba)
export const usuarioPruebaInterceptor: HttpInterceptorFn = (req, next) => {
  if (!environment.datosDePrueba || !req.url.startsWith(environment.apiUrl)) return next(req);
  return next(req.clone({ setHeaders: { 'X-Usuario-Prueba': usuarioPruebaActual() } }));
};