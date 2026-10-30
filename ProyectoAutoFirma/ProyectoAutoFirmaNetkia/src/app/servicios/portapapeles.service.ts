import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class PortapapelesService {
  //Copia la firma con formato (HTML) y sin formato (texto) a la vez
  async copiarConFormato(html: string, texto: string): Promise<void> {
    if (typeof ClipboardItem !== 'undefined' && navigator.clipboard?.write) {
      await navigator.clipboard.write([
        new ClipboardItem({
          'text/html': new Blob([html], { type: 'text/html' }),
          'text/plain': new Blob([texto], { type: 'text/plain' }),
        }),
      ]);
    } else {
      await navigator.clipboard.writeText(html);
    }
  }

  async copiarTexto(texto: string): Promise<void> {
    await navigator.clipboard.writeText(texto);
  }

  //Crea el archivo y lo descarga
  descargar(contenido: string, nombreArchivo: string): void {
    const url = URL.createObjectURL(new Blob([contenido], { type: 'text/html' }));
    const enlace = document.createElement('a');
    enlace.href = url;
    enlace.download = nombreArchivo;
    enlace.click();
    setTimeout(() => URL.revokeObjectURL(url), 1000);
  }
}
