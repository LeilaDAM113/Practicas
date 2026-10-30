import { Component, inject, input, output } from '@angular/core';
import { ICONOS } from '../../datos/firma.constantes';
import { FirmaService } from '../../servicios/firma.service';

@Component({
  selector: 'app-selector-iconos',
  templateUrl: './selector-iconos.html',
  styleUrl: './selector-iconos.css',
})
export class SelectorIconos {
  seleccionado = input.required<string>();
  automatico = input.required<string>();
  pista = input('');

  //Avisa a la pantalla de qué icono se ha pulsado
  elegir = output<string>();

  protected iconos = ICONOS;
  protected firma = inject(FirmaService);
}
