import { Component} from '@angular/core';
import { TitleComponent } from '../title/title.component';
import { AvatarComponent } from '../avatar/avatar.component'; 
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [TitleComponent, AvatarComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent{
  pageTitle ="MY APP";

  userInfo= {
    image:'https://freesvg.org/img/abstract-user-flat-4.png',
    role:'SALES'
  }

  constructor(){
  }
  
  onDataCheck(e: any){
    console.log(e);
  }
  /* Poner implements y todos los ciclos de vida separados por comas
 // detecta cada vez que nueva información llegue al componente
  ngOnChanges(changes: SimpleChanges): void {
    console.log('ngOnChanges ejecutado');
  }
  //se ejecuta una vez que el constructor haya sido llamado
  ngOnInit(): void {
    console.log('ngOnInit ejecutado');
    
  }
   //se ejecuta cada vez que algo pase/ocurra en la interfaz
    ngDoCheck(): void {
    console.log('ngDoCheck ejecutado');
  }
   // se ejecuta después de que el contenido esté iniciado
  ngAfterContentInit(): void {
     console.log('ngAfterContentInit ejecutado');
  }
  // revisa el contenido
  ngAfterContentChecked(): void {
      console.log('ngAfterContentChecked ejecutado');
  }
  // se ejecuta cuando toda la plantilla html está lista
    ngAfterViewInit(): void {
      console.log('ngAfterViewInit ejecutado');
  }
  //revisa que la plantilla de html esté bien
    ngAfterViewChecked(): void {
   console.log('ngAfterViewChecked ejecutado');
  }
// hace una limpieza 
   ngOnDestroy(): void {
    console.log('ngOnDestroy ejecutado');
  }
    */
}
