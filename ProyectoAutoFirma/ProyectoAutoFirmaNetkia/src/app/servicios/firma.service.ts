import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { ICONOS } from '../datos/firma.constantes';
import { DatosFirma, Icono } from '../datos/firma.modelos';

@Injectable({ providedIn: 'root' })
export class FirmaService {
  escapar(texto: string): string {
    return (texto ?? '')
      .replace(/&/g, '&amp;')
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;')
      .replace(/"/g, '&quot;');
  }

  normalizar(texto: string): string {
    return (texto ?? '').toLowerCase().normalize('NFD').replace(/[̀-ͯ]/g, '');
  }

  detectarIcono(departamento: string): string {
    const d = this.normalizar(departamento);
    const encontrado = ICONOS.find((icono) => icono.patron.test(d));
    return encontrado ? encontrado.id : 'comunicados';
  }

  iconoPorId(id: string): Icono {
    return ICONOS.find((icono) => icono.id === id) ?? ICONOS[0];
  }


  urlIcono(icono: Icono): string {
    return environment.firmas.imagenesPublicas + icono.archivo;
  }

  urlIconoPantalla(icono: Icono): string {
    return 'iconos/' + icono.archivo;
  }

  nombreArchivo(base: string): string {
    const limpio = this.normalizar(base).replace(/[^a-z0-9]+/g, '-').replace(/^-+|-+$/g, '');
    return `firma-${limpio || 'netkia'}.htm`;
  }

  construirHtml(d: DatosFirma): string {
    const e = (t: string) => this.escapar(t);
    const fuente = 'font-family:Lato,Arial,Tahoma,sans-serif;';
    const tablaInterior = 'margin:0 auto;border:0;border-collapse:collapse;border-spacing:0;background-color:#ffffff;';
    const atributos = 'border="0" cellspacing="0" cellpadding="0" align="center"';

    //Filas opcionales: solo aparecen si hay dato
    const filaLinea = d.linea
      ? `<tr><td colspan="3" style="text-align:center;"><p style="padding:0;margin:0;font-size:14px;color:#666666;">${e(d.linea)}</p></td></tr>`
      : '';
    const filaNota = d.nota
      ? `<tr><td colspan="2" style="padding-top:10px;text-align:center;font-size:12px;color:#4e5fbf;${fuente}">${e(d.nota)}</td></tr>`
      : '';

    return `
<table style="max-width:530px;width:530px;border:none;border-collapse:collapse;border-spacing:0;background-color:#ffffff;${fuente}" border="0" cellspacing="0" cellpadding="0">
  <tr><td colspan="2" style="height:20px;"></td></tr>
  <tr>
    <td style="border-right:1px solid #dddddd;">
      <table style="${tablaInterior}" ${atributos}>
        <tr>
          <td style="width:30px;"></td>
          <td style="text-align:center;width:200px;"><img width="80" src="${this.urlIcono(d.icono)}" alt="${e(d.icono.etiqueta)}"></td>
          <td style="width:30px;"></td>
        </tr>
        <tr><td colspan="3" style="height:10px;"></td></tr>
      </table>
    </td>
    <td>
      <table style="${tablaInterior}" ${atributos}>
        <tr>
          <td style="width:30px;"></td>
          <td><img src="${environment.firmas.logo}" alt="Netkia" width="120" style="display: block; max-width: 100%; height: auto;"></td>
          <td style="width:30px;"></td>
        </tr>
      </table>
    </td>
  </tr>
  <tr>
    <td style="border-right:1px solid #dddddd;vertical-align:top;">
      <table style="${tablaInterior}" ${atributos}>
        <tr><td colspan="3" style="text-align:center;padding:0 25px;"><h3 style="padding:0;margin:0;font-size:15px;line-height:17px;font-weight:900;text-transform:capitalize;">${e(d.nombre)}</h3></td></tr>
        <tr><td colspan="3" style="height:3px;"></td></tr>
        ${filaLinea}
        <tr><td colspan="3" style="text-align:center;"><a style="font-size:14px;${fuente}color:#666666;text-decoration:none;" href="mailto:${e(d.correo)}">${e(d.correo)}</a></td></tr>
      </table>
    </td>
    <td>
      <table style="${tablaInterior}" ${atributos}>
        <tr>
          <td style="width:30px;"></td>
          <td><h3 style="padding:0;margin:0;font-size:15px;font-weight:900;"><a style="${fuente}color:#000000;text-decoration:none;" href="https://www.netkia.es">www.netkia.es</a></h3></td>
          <td style="width:30px;"></td>
        </tr>
        <tr><td colspan="3" style="height:3px;"></td></tr>
        <tr>
          <td style="width:30px;"></td>
          <td><p style="padding:0;margin:0;font-size:14px;color:#666666;">${e(d.telefonos)}</p></td>
          <td style="width:30px;"></td>
        </tr>
        <tr>
          <td style="width:30px;"></td>
          <td><a style="font-size:15px;${fuente}color:#666666;text-decoration:none;" href="mailto:info@netkia.es">info@netkia.es</a></td>
          <td style="width:30px;"></td>
        </tr>
      </table>
    </td>
  </tr>
  <tr><td colspan="2" style="height:15px;"></td></tr>
  ${filaNota}
</table>
<table style="max-width:530px;width:530px;border:none;border-collapse:collapse;border-spacing:0;background-color:#ffffff;${fuente}" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="text-align:center;font-size:12px;">
      <table style="margin:0 auto;border:0;border-collapse:collapse;border-spacing:0;" ${atributos}>
        <tr>
          <td>
            <p style="margin:0;font-size:12px;${fuente}color:#000000;">
              <a style="color:#000000;text-decoration:none;" target="_blank" href="https://maps.app.goo.gl/k8JSbnFA8fAhjv1v6">Cantabria</a>
              &nbsp;&nbsp;.&nbsp;&nbsp;
              <a style="color:#000000;text-decoration:none;" target="_blank" href="https://maps.app.goo.gl/hXPbpLwJxFXsBeFF9">Madrid</a>
              &nbsp;&nbsp;.&nbsp;&nbsp;
              <a style="color:#000000;text-decoration:none;" target="_blank" href="https://maps.app.goo.gl/mas6nubKuHr4JKsA9">Barcelona</a>
            </p>
          </td>
          <td style="padding-left:12px;height:33px;vertical-align:middle;">
            <img src="${environment.firmas.logoPitma}" alt="PITMA">
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>`.trim();
  }

  //La firma sin formato (para el móvil)
  construirTexto(d: DatosFirma): string {
    const lineas = [d.nombre];
    if (d.linea) lineas.push(d.linea);
    lineas.push(d.correo, '', 'Netkia · www.netkia.es', d.telefonos, 'info@netkia.es', 'Cantabria · Madrid · Barcelona');
    if (d.nota) lineas.push('', d.nota);
    return lineas.join('\n');
  }

  //Página .html completa para "Descargar .html".
  construirDocumento(d: DatosFirma): string {
    return [
      '<!DOCTYPE html>',
      '<html lang="es">',
      `<head><meta charset="utf-8"><title>Firma ${this.escapar(d.nombre)}</title></head>`,
      '<body>',
      this.construirHtml(d),
      '</body>',
      '</html>',
      '',
    ].join('\n');
  }
}
