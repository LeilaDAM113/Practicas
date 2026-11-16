export type Entorno = 'Dev' | 'Test' | 'Prod';
export type Exposicion = 'Publico' | 'Privado' | 'Limitado';
export type TipoTecnologia = 'Framework' | 'Desarrollo propio' | 'Herramienta';

export const ENTORNOS: Entorno[] = ['Dev', 'Test', 'Prod'];
export const EXPOSICIONES: Exposicion[] = ['Publico', 'Privado', 'Limitado'];
export const TIPOS_TECNOLOGIA: TipoTecnologia[] = ['Framework', 'Desarrollo propio', 'Herramienta'];

export interface Aplicacion {
  id?: number;
  proyecto_id?: number;
  nombre: string;
  entorno: Entorno;
  url: string | null;
  exposicion: Exposicion;
  tipo_tecnologia: TipoTecnologia;
  framework_nombre: string | null;
  framework_version: string | null;
  lenguaje: string | null;
  lenguaje_version: string | null;
  gestor_paquetes: string | null;
  gestor_version: string | null;
  url_repositorio: string | null;
}

export interface ProyectoDatos {
  nombre: string;
  cliente: string;
  responsable: string;
  mantenimiento_contratado: boolean;
}

export interface Proyecto extends ProyectoDatos {
  id: number;
  creado_por_nombre: string;
  creado_en: string;
  puede_editar: boolean;
  aplicaciones: Aplicacion[];
}

export interface Usuario {
  nombre: string;
  email: string;
  roles: string[];
}

export interface ResultadoBusqueda extends Aplicacion {
  proyecto_nombre: string;
  cliente: string;
  responsable: string;
}

export interface Hallazgo {
  paquete: string;
  version: string;
  ecosistema: string;
  vuln_id: string;
  alias: string | null;
  severidad: string;
  resumen: string;
  version_corregida: string | null;
  aproximado: boolean;
}

export interface Analisis {
  id: number;
  fichero: string;
  total_paquetes: number;
  total_vulnerables: number;
  realizado_por: string;
  realizado_en: string;
  hallazgos: Hallazgo[];
}
