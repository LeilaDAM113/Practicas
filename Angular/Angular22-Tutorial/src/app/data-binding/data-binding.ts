import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  imports: [FormsModule],
  selector: 'app-data-binding',
  styleUrl: './data-binding.css',
  templateUrl: './data-binding.html',
})
export class DataBinding {
  name : string= "FED Learning"

  topic : string= "4 Types of Data Binding..!"

  image: string="https://media.istockphoto.com/id/2200665035/es/vector/dibujo-lineal-simple-de-una-casa-con-ventana-de-cuatro-paneles-y-chimenea.jpg?s=612x612&w=0&k=20&c=-4kX5lxD3AwCs7NJtUOfR_Cq2s3ds2Hmwc4KYA_v_7Q="

  onSubmitClick(){
    alert("Data Saved Successfully.")
  }
  onCountryChange(){
    alert("Country has changed.")
  }
}
