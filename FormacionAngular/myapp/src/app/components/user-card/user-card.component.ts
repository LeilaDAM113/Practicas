import { Component } from '@angular/core';
import { JsonPipe } from '@angular/common'; 

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [JsonPipe],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.scss'
})
export class UserCardComponent {
 name = 'Jhon'
  surname = 'Doe'
  age = 33
  married = true
  address = {
    country: 'UK',
    city: 'Damascus',
    street: 'Liberty'
  }
   private dni = '34432432'
  public nationality = 'Japanese'
  getDate(){
    return new Date()
  }
}
