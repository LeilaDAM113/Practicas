import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from './components/header/header.component'; 
import { FooterComponent } from './components/footer/footer.component';
import { RouterOutlet } from '@angular/router';
import { AvatarComponent } from './components/avatar/avatar.component';
import { BtnComponent } from './components/btn/btn.component';
import { LinkComponent } from './components/link/link.component';
import { UserCardComponent } from './components/user-card/user-card.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { NgFor, NgIf } from '@angular/common';
import { ComponentsModule } from './components/components.module';
import { ProductsComponent } from './pages/products/products.component';
import { PagesModule } from './pages/pages.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HeaderComponent, ComponentsModule, PagesModule, CommonModule, RouterOutlet, FormsModule],
 /*  imports: [HeaderComponent, FooterComponent, RouterOutlet, AvatarComponent, BtnComponent, LinkComponent, UserCardComponent, ProductCardComponent], */
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'myapp';
  
   styles = {
    display: 'flex',
    'flex-direction': 'column',
    'align-items': 'center',
    padding: '20px',
    width: '200px',
  }
}
