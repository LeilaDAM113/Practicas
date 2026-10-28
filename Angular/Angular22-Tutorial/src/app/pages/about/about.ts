import { NgClass, NgStyle, NgIf, NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { Component } from '@angular/core';
import { TextStyle } from '../../text-style';


@Component({
  imports: [NgClass, NgStyle, NgIf, NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault, TextStyle],
  selector: 'app-about',
  styleUrl: './about.css',
  templateUrl: './about.html',
})
export class About {
  isActive=false
  textColor='red'
  isLoggedIn=false
  role="userrrrr"
 users=['John', 'Peter' , 'Bob']
 //users=[]
  status='active'
}
