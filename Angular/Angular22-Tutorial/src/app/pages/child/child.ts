import { Component, input, model, output, signal } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-child',
  styleUrl: './child.css',
  templateUrl: './child.html',
})
export class Child {
  //1. input()
  userName=input<string>('')
  quantityValue=input<number>(0)
  //2. output()
  quantityChanged=output<number>()
  increaseQuantity(){
    this.quantityChanged.emit(this.quantityValue()+1)
  }
  //3. model()
  quantity=model<number>(1)
  increase(){
    this.quantity.update(value=> value + 1)
  }
  decrease(){
    this.quantity.update(value=> value - 1)
  }
//5. viewChild
message = signal('Hello from Child')
showMessage(){
  this.message.set('Message changed by Parent')
}
resetMessage(){
  this.message.set('Message reset by Parent')
}


  // username=input.required<string>()
  // saved=output()
  // selected=output<string>()
  // quantity= model(1)

  // increase(){
  //   //this.quantity.set(4)
  //   this.quantity.update(q=> q+1)
  // }
  // selectUser(){
  //   this.selected.emit('John')
  // }
  // onSave(){
  //   this.saved.emit()
  // }
  // constructor(){
  //   this.username.set('John')
  // }
}
