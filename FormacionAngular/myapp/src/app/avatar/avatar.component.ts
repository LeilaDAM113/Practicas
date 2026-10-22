import { Component, Input } from '@angular/core';
import { NgStyle, NgClass } from '@angular/common';

@Component({
  selector: 'app-avatar',
  standalone: true, 
  imports: [NgStyle, NgClass],
  template: `
 <img
 class="avatar"
 [ngClass]="userInfo.role === 'ADMIN'? 'admin' : userInfo.role === 'SALES'? 'sales': ''"
 class="avatar" [src]="userInfo.image"
 [ngStyle]="{'border': userInfo.role === 'ADMIN' ? '2px solid cyan' : '2px solid yellow'}">
   <!--  <h1>Ejemplo de un Inline template</h1>
    <p>contenido</p> -->
  `, 
  styles: [
  `.avatar { height: 50px; width: 50px; padding: 5px}`,
  `.admin { border-radius: 100%; }`,
  `.sales { border-radius: 18px; }`,
]
})
export class AvatarComponent {
@Input() userInfo: any;
}
