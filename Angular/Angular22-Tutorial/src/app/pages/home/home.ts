import { Component, signal, WritableSignal, ViewChild, ElementRef, OnInit } from '@angular/core';
import { Profile } from '../profile/profile';
import { TextStyle } from '../../text-style';

@Component({
  imports: [Profile, TextStyle],
  selector: 'app-home',
  styleUrl: './home.css',
  templateUrl: './home.html',
})
export class Home  { 
  // count: WritableSignal<number> = signal(0)
  count = signal(0);

  setCount(){
    this.count.set(10)
    this.count.update(value=> value + 1)
  }

  //console.log(this.count())
  //  name=signal('abc')
  //  isLoggedIn = signal(true)
  //  items = signal<string[]>([])
  //  user = signal({
  //   name: 'John',
  //   age:40
  //  })

  title = "Home Component";
  price = 500;
  quantity = 2;

  @ViewChild('email') email!: ElementRef;

  focusInput() {
    this.email.nativeElement.focus();
  }

  getMessage() {
    return 'Example of Template Expressions';
  }

  // showMessage(event:Event){
  //   console.log(event.target)
  // }
  showMessage(name: string) {
    console.log(name);
  }

  getValue(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    console.log(value);
  }

  keyPreassed(event: KeyboardEvent) {
    console.log(event.key);
  }

  search() {
    console.log("inside search");
  }

  showName(value: string) {
    console.log(value);
  }
}
