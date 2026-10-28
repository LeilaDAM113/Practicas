import { CartService } from './../../Services/cart-service';
import { Component, signal, computed, effect, inject} from '@angular/core';

@Component({
  imports: [],
  selector: 'app-signal',
  styleUrl: './signal.css',
  templateUrl: './signal.html',
})
export class Signal {
cartService = inject(CartService)

//   count = signal(0)
//   price = signal(100)
//   quantity =signal(2)
//   isDiscountApplied=signal(false)

//  total = computed(() => {
//   if(this.isDiscountApplied()){
//      //console.log('Calculating total...')
//   return this.price() * this.quantity() * 0.9;
//   }
//   return this.price() * this.quantity()})
  
//   theme = signal('light')
//   constructor(){
//   effect(()=>{
//     //console.log(this.count())
//     localStorage.setItem('theme', this.theme())
//   })
// }
//  readonlyCount =this.count.asReadonly()

  increment(){
    //this.count.update(value=> value+1)
  }
  decrement(){
    //this.count.update(value=> value -1)
  }
  reset(){
    //this.total()
    // this.count.set(10)
    //this.price.set(200)
    // this.quantity.set(3)
    // this.total.set(600)
    //this.theme.set('dark')
    //this.readonlyCount.set(14)
  }
}
