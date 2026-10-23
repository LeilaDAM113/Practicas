import { AvatarComponent } from './avatar/avatar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { TitleComponent } from './title/title.component';
import { BtnComponent } from './btn/btn.component';
import { IconComponent } from './icon/icon.component';
import { LinkComponent } from './link/link.component';
import { UserCardComponent } from './user-card/user-card.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { RouterOutlet } from '@angular/router';
import { RouterLink } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
     CommonModule, 
     AvatarComponent, 
     HeaderComponent,
     FooterComponent, 
     TitleComponent,
     BtnComponent,
     IconComponent,
     LinkComponent,
     UserCardComponent,
     ProductCardComponent,
     RouterLink,
     RouterOutlet
  ],
   exports: [ 
    HeaderComponent,
    FooterComponent,
    TitleComponent,
    BtnComponent,
    IconComponent,
    LinkComponent,
    UserCardComponent,
    ProductCardComponent,
     RouterLink,
     RouterOutlet
  ]
})
export class ComponentsModule { }
