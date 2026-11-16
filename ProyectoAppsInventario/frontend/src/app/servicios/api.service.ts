import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Analisis, Aplicacion, Proyecto, ProyectoDatos, ResultadoBusqueda, Usuario } from '../datos/inventario.modelos';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private http = inject(HttpClient);
  private url = environment.apiUrl;

  me() {
    return this.http.get<Usuario>(`${this.url}/me`);
  }

  //Proyectos
  proyectos() {
    return this.http.get<Proyecto[]>(`${this.url}/proyectos`);
  }
  proyecto(id: number) {
    return this.http.get<Proyecto>(`${this.url}/proyectos/${id}`);
  }
  crearProyecto(p: ProyectoDatos) {
    return this.http.post<Proyecto>(`${this.url}/proyectos`, p);
  }
  actualizarProyecto(id: number, p: ProyectoDatos) {
    return this.http.put<Proyecto>(`${this.url}/proyectos/${id}`, p);
  }
  borrarProyecto(id: number) {
    return this.http.delete<void>(`${this.url}/proyectos/${id}`);
  }

  //Aplicaciones
  aplicacion(id: number) {
    return this.http.get<Aplicacion>(`${this.url}/aplicaciones/${id}`);
  }
  crearAplicacion(proyectoId: number, a: Aplicacion) {
    return this.http.post<Aplicacion>(`${this.url}/proyectos/${proyectoId}/aplicaciones`, a);
  }
  actualizarAplicacion(id: number, a: Aplicacion) {
    return this.http.put<Aplicacion>(`${this.url}/aplicaciones/${id}`, a);
  }
  borrarAplicacion(id: number) {
    return this.http.delete<void>(`${this.url}/aplicaciones/${id}`);
  }

  //Buscador
  buscar(filtros: Record<string, string>) {
    let params = new HttpParams();
    Object.entries(filtros).forEach(([k, v]) => {
      if (v && v.trim()) params = params.set(k, v.trim());
    });
    return this.http.get<ResultadoBusqueda[]>(`${this.url}/buscar`, { params });
  }

  //Fase 2: análisis de dependencias
  analizar(appId: number, fichero: File) {
    const fd = new FormData();
    fd.append('fichero', fichero);
    return this.http.post<Analisis>(`${this.url}/aplicaciones/${appId}/analisis`, fd);
  }
  historialAnalisis(appId: number) {
    return this.http.get<Analisis[]>(`${this.url}/aplicaciones/${appId}/analisis`);
  }
}
