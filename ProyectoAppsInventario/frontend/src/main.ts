import { bootstrapApplication } from '@angular/platform-browser';

async function arrancar() {
  //Si volvemos de Microsoft (/redirect), arrancamos solo /redirect
  if (window.location.pathname.startsWith('/redirect')) {
    const { Redirect } = await import('./app/auth/redirect');
    return bootstrapApplication(Redirect);
  }
  const [{ App }, { appConfig }] = await Promise.all([import('./app/app'), import('./app/app.config')]);
  return bootstrapApplication(App, appConfig);
}

arrancar().catch((err) => console.error(err));
