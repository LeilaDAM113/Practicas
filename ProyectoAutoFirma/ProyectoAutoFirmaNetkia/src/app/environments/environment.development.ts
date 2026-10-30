export const environment = {
   production: false,

  // true = usa un empleado inventado, sin login real. Ponlo a false en el paso 13.
  datosDePrueba: true,

  // true = en "Firma de departamento" salen todos los buzones.
  mostrarTodosLosBuzones: true,

  msal: {
    clientId: '03b4dd03-4c2d-4995-b4fb-0ba2c5a94a9a',
    tenantId: '621db785-00d7-4ced-b451-0f5696381174',
  },

  graph: {
    url: 'https://graph.microsoft.com/v1.0',
    scopes: ['User.Read'],
  },

  firmas: {
    imagenesPublicas: 'https://www.netkia.es/firmas/departamentos/',
    logo: 'https://www.netkia.es/firmas/img/logo-netkia-15ani2.jpg',
    logoPitma: 'https://www.netkia.es/firmas/fotos-2022/logo-pitma.jpg',
  },
};
