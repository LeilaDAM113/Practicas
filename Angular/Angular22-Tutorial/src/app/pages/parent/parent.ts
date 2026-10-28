import { CartService } from './../../Services/cart-service';
import { Component, inject, signal, viewChild } from '@angular/core';
import { Child } from '../child/child';

@Component({
  imports: [Child],
  selector: 'app-parent',
  styleUrl: './parent.css',
  templateUrl: './parent.html',
})
export class Parent {
  child= viewChild.required(Child)
  changeChildMessage(){
    this.child().showMessage()
  }
  resetChildMessage(){
    this.child().resetMessage()
  }
  cartService= inject(CartService)
  username='Vishal'
  quantity=4
  //userName="Peter"
  //quantity=signal(1)
  parentQuantity=1
  updateQuantity(value:number){
this.parentQuantity=value
  }
 handleSave(){
  console.log('Saved event ocurre from child')
 }

 handleSelection(user:string){
  console.log(user)
  //console.log('Saved event ocurre from child')
 }
}
