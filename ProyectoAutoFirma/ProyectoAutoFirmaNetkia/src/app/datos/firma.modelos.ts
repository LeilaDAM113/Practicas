//Datos del usuario que vienen de Microsoft
export interface PerfilUsuario {
  nombre: string;
  correo: string;
  departamento: string;
  cargo: string;
  empresa: string;
  telefonoOficina: string;
  movil: string;
}

//Icono de departamento
export interface Icono {
  id: string;
  etiqueta: string;
  archivo: string;
  patron: RegExp;  //automatiza la asignación de un icono a un departamento mediante la búsqueda de palabras clave
}

//Buzón compartido (firma departamento)
export interface Buzon {
  id: string;
  nombre: string;
  linea: string;
  correo: string;
  telefono: string;
  icono: string;
  grupoId: string; //ID del grupo de Microsoft cuyos miembros pueden usarlo
}

//Pasos para instalar la firma en un programa de correo
export interface GuiaInstalacion {
  id: string;
  etiqueta: string;
  pasos: string[];
}

//Lo necesario para construir una firma
export interface DatosFirma {
  nombre: string;
  linea: string;
  correo: string;
  telefonos: string;
  icono: Icono;
  nota: string;            
  nombreArchivo: string; 
}
