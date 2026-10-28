import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {

  private router =inject(Router);
onLogin(){
  //API call to validate user code for navigation
this.router.navigate(['/pages/home']);
}
onRegister(){
  this.router.navigateByUrl('/pages/register');
}
}
