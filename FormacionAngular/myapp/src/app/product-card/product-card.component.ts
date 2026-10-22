import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UpperCasePipe } from '@angular/common';
import { DatePipe } from '@angular/common';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [FormsModule, UpperCasePipe, DatePipe, CurrencyPipe],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss'
})
export class ProductCardComponent {
  @Input() product: any
  productImageStyle={
    border:'1px solid black',
    filter: 'sepia(0)'
  }
  
  formState=false
  
  address= ''
  postalCode = 0
  
  orderProduct(){
    console.log(`Dirección de usuario: ${this.address}`)
    console.log(`Código postal: ${this.postalCode}`)
  }

  buyProduct(){
    console.log('compraremos un producto')
    this.formState=true
  }

   addToCart(){
    console.log('agregamos un producto al carro de compras')
  }

  onMouseEnter(){
    console.log('mouse enter')
    this.productImageStyle={...this.productImageStyle,filter: 'sepia(0.3)'}
  }

  onMouseLeave(){
    console.log('mouse leave')
    this.productImageStyle={...this.productImageStyle,filter: 'sepia(0)'}
  }
}
