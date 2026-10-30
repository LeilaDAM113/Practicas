import { Component, computed, signal } from '@angular/core';
import { GUIAS } from '../../datos/firma.constantes';

@Component({
  selector: 'app-guia-instalacion',
  templateUrl: './guia-instalacion.html',
  styleUrl: './guia-instalacion.css',
})
export class GuiaInstalacion {
  protected guias = GUIAS;
  protected guiaId = signal('outlook');
  protected guia = computed(() => GUIAS.find((g) => g.id === this.guiaId()) ?? GUIAS[0]);
}
