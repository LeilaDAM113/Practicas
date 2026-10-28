import { computed, effect, Service, signal } from '@angular/core';

@Service()
export class CartService {

  price = signal(100)
  quantity =signal(2)

  private notificationCount = signal(1)
  readonly notifications=this.notificationCount.asReadonly()

total = computed(() => {
  return this.price() * this.quantity();
})

readonlyQuantity= this.quantity.asReadonly
constructor(){
  effect(()=>{
    //console.log(this.count())
    localStorage.setItem('cart-total', this.total().toExponential.toString())
  })
}
increaseQuantity(){
    this.quantity.update(q => q +1)
}
changePrice(price:number){
    this.price.set(price)
}
}
