import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-register',
  styleUrl: './register.css',
  templateUrl: './register.html',
})
export class Register {
  private router = inject(Router)
onRegister(){
this.router.navigate(['/pages/login'])
}
onCancel(){
this.router.navigate(['/pages/login'])
}

}
