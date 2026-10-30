import { Component, computed, DestroyRef, inject, input, signal } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { DatosFirma } from '../../datos/firma.modelos';
import { FirmaService } from '../../servicios/firma.service';
import { PortapapelesService } from '../../servicios/portapapeles.service';

type Pestana = 'preview' | 'html' | 'text';
type Estado = 'rich' | 'html' | 'text' | 'file' | 'error';

const MENSAJES: Record<Estado, string> = {
  rich: 'Firma copiada. Pégala en Outlook o Gmail con Ctrl+V.',
  html: 'Código HTML copiado.',
  text: 'Texto plano copiado.',
  file: 'Archivo .htm descargado.',
  error: 'No se ha podido acceder al portapapeles. Prueba otra vez o usa la pestaña HTML.',
};

@Component({
  selector: 'app-vista-previa',
  templateUrl: './vista-previa.html',
  styleUrl: './vista-previa.css',
})
export class VistaPrevia {
  //Datos que manda la pantalla de la firma
  datos = input.required<DatosFirma>();

  private firma = inject(FirmaService);
  private portapapeles = inject(PortapapelesService);
  private sanitizer = inject(DomSanitizer);

  protected readonly pestanas: { id: Pestana; etiqueta: string }[] = [
    { id: 'preview', etiqueta: 'Vista previa' },
    { id: 'html', etiqueta: 'HTML' },
    { id: 'text', etiqueta: 'Texto plano' },
  ];
  protected pestana = signal<Pestana>('preview');
  protected estado = signal<Estado | null>(null);
  private temporizador?: ReturnType<typeof setTimeout>;

  //Se recalculan solos cuando cambian los datos.
  protected html = computed(() => this.firma.construirHtml(this.datos()));
  protected texto = computed(() => this.firma.construirTexto(this.datos()));
  //Se crea la firma con formato
  protected htmlSeguro = computed(() => this.sanitizer.bypassSecurityTrustHtml(this.html()));
  protected mensaje = computed(() => {
    const e = this.estado();
    return e ? MENSAJES[e] : 'La firma se copia con formato: imágenes, enlaces y tipografía incluidos.';
  });

  constructor() {
    inject(DestroyRef).onDestroy(() => clearTimeout(this.temporizador));
  }

  //Botón "Copiar firma"
  protected async copiarFirma(): Promise<void> {
    try {
      await this.portapapeles.copiarConFormato(this.html(), this.texto());
      this.avisar('rich');
    } catch {
      this.avisar('error');
    }
  }

  //Botón "Copiar HTML"
  protected async copiarHtml(): Promise<void> {
    try {
      await this.portapapeles.copiarTexto(this.html());
      this.avisar('html');
    } catch {
      this.avisar('error');
    }
  }

  //Botón "Copiar texto plano"
  protected async copiarTextoPlano(): Promise<void> {
    try {
      await this.portapapeles.copiarTexto(this.texto());
      this.avisar('text');
    } catch {
      this.avisar('error');
    }
  }

  //Botón "Descargar .html"
  protected descargar(): void {
    try {
      const d = this.datos();
      this.portapapeles.descargar(this.firma.construirDocumento(d), d.nombreArchivo);
      this.avisar('file');
    } catch {
      this.avisar('error');
    }
  }

  //Enseña un mensaje y lo quita a los 3 segundos
  private avisar(estado: Estado): void {
    clearTimeout(this.temporizador);
    this.estado.set(estado);
    this.temporizador = setTimeout(() => this.estado.set(null), 3000);
  }
}
