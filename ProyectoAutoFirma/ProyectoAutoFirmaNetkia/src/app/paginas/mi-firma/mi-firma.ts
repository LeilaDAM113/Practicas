import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Cabecera } from '../../compartido/cabecera/cabecera';
import { GuiaInstalacion } from '../../compartido/guia-instalacion/guia-instalacion';
import { Pie } from '../../compartido/pie/pie';
import { SelectorIconos } from '../../compartido/selector-iconos/selector-iconos';
import { SelectorModo } from '../../compartido/selector-modo/selector-modo';
import { VistaPrevia } from '../../compartido/vista-previa/vista-previa';
import { NOTA_ITECAN, TELEFONO_GENERAL } from '../../datos/firma.constantes';
import { DatosFirma } from '../../datos/firma.modelos';
import { FirmaService } from '../../servicios/firma.service';
import { PerfilService } from '../../servicios/perfil.service';

@Component({
  selector: 'app-mi-firma',
  imports: [FormsModule, Cabecera, Pie, SelectorModo, SelectorIconos, VistaPrevia, GuiaInstalacion],
  templateUrl: './mi-firma.html',
  styleUrl: './mi-firma.css',
})
export class MiFirma implements OnInit {
  protected perfilService = inject(PerfilService);
  private firma = inject(FirmaService);

  protected perfil = this.perfilService.perfil;

  //Campos que el usuario puede cambiar.
  protected departamento = signal('');
  protected telefonoOficina = signal('');
  protected movil = signal('');
  protected iconoElegido = signal<string | null>(null); // null = el automático

  protected iconoAuto = computed(() => this.firma.detectarIcono(this.departamento()));
  protected iconoActual = computed(() => this.iconoElegido() ?? this.iconoAuto());

  //Todo lo que necesita la vista previa. Se recalcula solo
  protected datos = computed<DatosFirma>(() => {
    const nombre = this.perfil()?.nombre ?? '';
    const movil = this.movil().trim();
    return {
      nombre,
      linea: this.departamento().trim(),
      correo: this.perfil()?.correo ?? '',
      telefonos: this.telefonoOficina().trim() + (movil ? ' / ' + movil : ''),
      icono: this.firma.iconoPorId(this.iconoActual()),
      nota: this.perfilService.esDeItecan() ? NOTA_ITECAN : '',
      nombreArchivo: this.firma.nombreArchivo(nombre),
    };
  });

  async ngOnInit(): Promise<void> {
    await this.perfilService.cargarPerfil();
    this.restaurar();
  }

  //Botón "Restaurar valores"
  protected restaurar(): void {
    const p = this.perfil();
    if (!p) return;
    this.departamento.set(p.departamento || p.cargo);
    this.telefonoOficina.set(p.telefonoOficina || TELEFONO_GENERAL);
    this.movil.set(p.movil);
    this.iconoElegido.set(null);
  }
}
