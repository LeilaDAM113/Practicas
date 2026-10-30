import { Buzon, GuiaInstalacion, Icono, PerfilUsuario } from './firma.modelos';

export const TELEFONO_GENERAL = '942 946 896';

export const NOTA_ITECAN = 'ITECAN ahora forma parte de Netkia';

export const ICONOS: Icono[] = [
  //El orden importa: se usa el PRIMER icono cuyo patrón encaje con el departamento
  { id: 'direccion', etiqueta: 'Dirección', archivo: 'icono-direccion.png', patron: /direcci|gerencia|ceo/ },
  { id: 'administracion', etiqueta: 'Administración', archivo: 'icono-administracion.png', patron: /administra|contab|finanz|rrhh|recursos humanos/ },
  { id: 'comunicados', etiqueta: 'Comunicados', archivo: 'icono-comunicados.png', patron: /comunica/ },
  { id: 'diseno', etiqueta: 'Diseño', archivo: 'icono-diseno.png', patron: /diseno/ },
  { id: 'marketing', etiqueta: 'Marketing', archivo: 'icono-marketing.png', patron: /marketing|comercial|ventas/ },
  { id: 'desarrollo-apps', etiqueta: 'Apps móviles', archivo: 'icono-desarrollo-apps.png', patron: /apps|movil/ },
  { id: 'desarrollo', etiqueta: 'Desarrollo', archivo: 'icono-desarrollo.png', patron: /desarrollo|software|ingenier|programa/ },
  { id: 'bi', etiqueta: 'Business Intelligence', archivo: 'icono-bi.png', patron: /\bbi\b|business|intelligence|datos/ },
  { id: 'sistemas-cloud', etiqueta: 'Sistemas cloud', archivo: 'icono-sistemas-cloud.png', patron: /cloud|nube/ },
  { id: 'sistemas-seguridad', etiqueta: 'Sistemas y seguridad', archivo: 'icono-sistemas-seguridad.png', patron: /sistemas|seguridad|ciber/ },
  { id: 'soporte', etiqueta: 'Soporte', archivo: 'icono-soporte.png', patron: /soporte|help ?desk|atencion/ },
  { id: 'telefonia', etiqueta: 'Telefonía', archivo: 'icono-telefonia.png', patron: /telefon|voip/ },
  { id: 'almacen', etiqueta: 'Almacén', archivo: 'almacen-netkia.jpg', patron: /almacen|logistic/ },
];


export const BUZONES: Buzon[] = [
  { id: 'sistemas', nombre: 'Departamento de Sistemas', linea: 'Sistemas y cloud', correo: 'sistemas@netkia.es', telefono: TELEFONO_GENERAL, icono: 'sistemas-cloud', grupoId: 'PENDIENTE' },
  { id: 'ciber', nombre: 'Ciberseguridad', linea: 'Sistemas y seguridad', correo: 'ciberseguridad@netkia.es', telefono: TELEFONO_GENERAL, icono: 'sistemas-seguridad', grupoId: 'PENDIENTE' },
  { id: 'soporte', nombre: 'Help Desk', linea: 'Soporte técnico', correo: 'soporte@netkia.es', telefono: TELEFONO_GENERAL, icono: 'soporte', grupoId: 'PENDIENTE' },
  { id: 'administracion', nombre: 'Administración', linea: 'Dpto. Administración', correo: 'administracion@netkia.es', telefono: TELEFONO_GENERAL, icono: 'administracion', grupoId: 'PENDIENTE' },
  { id: 'comunicados', nombre: 'Netkia', linea: 'Comunicados', correo: 'comunicados@netkia.es', telefono: TELEFONO_GENERAL, icono: 'comunicados', grupoId: 'PENDIENTE' },
];

export const GUIAS: GuiaInstalacion[] = [
  { id: 'outlook', etiqueta: 'Outlook nuevo / web', pasos: [
    'Pulsa «Copiar firma».',
    'En Outlook abre Configuración (rueda dentada) › Cuentas › Firmas.',
    'Pulsa «+ Nueva firma», ponle nombre y pega con Ctrl+V (Cmd+V en Mac).',
    'Elígela como predeterminada para mensajes nuevos y respuestas, y guarda.',
  ] },
  { id: 'clasico', etiqueta: 'Outlook clásico', pasos: [
    'Pulsa «Copiar firma».',
    'En Outlook ve a Archivo › Opciones › Correo › Firmas.',
    'Pulsa «Nueva», ponle nombre y pega la firma en el editor.',
    'Asígnala a mensajes nuevos y a respuestas/reenvíos y pulsa Aceptar.',
  ] },
  { id: 'gmail', etiqueta: 'Gmail', pasos: [
    'Pulsa «Copiar firma».',
    'En Gmail abre Configuración › Ver todos los ajustes › General.',
    'En «Firma» pulsa «Crear», ponle nombre y pega la firma.',
    'Selecciónala como predeterminada y pulsa «Guardar cambios» al final de la página.',
  ] },
  { id: 'movil', etiqueta: 'Móvil', pasos: [
    'Pulsa «Copiar texto plano»: las apps móviles no admiten bien firmas con imágenes.',
    'En Outlook para iOS o Android abre Configuración › Firma.',
    'Borra la firma por defecto y pega la tuya.',
    'Vuelve atrás para guardar.',
  ] },
];

//Empleado inventado para el modo de prueba
export const PERFIL_PRUEBA: PerfilUsuario = {
  nombre: 'Nadia Prida Romano',
  correo: 'nadia.prida@netkia.es',
  departamento: 'Dpto. Marketing y diseño',
  cargo: '',
  empresa: 'Netkia',
  telefonoOficina: TELEFONO_GENERAL,
  movil: '',
};
