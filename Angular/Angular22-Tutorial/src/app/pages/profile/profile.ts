import { Component } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-profile',
  styleUrl: './profile.css',
  templateUrl: './profile.html',
})
export class Profile {
   hasUnsavedChanges = () => true; 

   updateProfile(){
      console.log("Inside Profile Component")
   }
}
