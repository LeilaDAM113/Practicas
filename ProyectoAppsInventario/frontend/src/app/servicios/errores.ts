import { HttpErrorResponse } from '@angular/common/http';

//Convierte un error del backend en un texto para enseñar al usuario
export function mensajeError(e: unknown, porDefecto = 'Ha ocurrido un error. Inténtalo de nuevo.'): string {
  if (e instanceof HttpErrorResponse) {
    const detalle = e.error?.detail;
    if (typeof detalle === 'string') return detalle;
    if (Array.isArray(detalle) && detalle.length) {
      //Errores de validación de FastAPI (422)
      return detalle.map((d: { loc?: unknown[]; msg?: string }) => `${(d.loc ?? []).slice(-1)[0]}: ${d.msg}`).join(' · ');
    }
    if (e.status === 0) return 'No se puede conectar con el servidor.';
    if (e.status === 403) return 'No tienes permiso para hacer esto.';
    if (e.status === 404) return 'No encontrado.';
  }
  return porDefecto;
}
