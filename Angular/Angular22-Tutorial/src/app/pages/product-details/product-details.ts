import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-product-details',
  styleUrl: './product-details.css',
  templateUrl: './product-details.html',
})
export class ProductDetails implements OnInit{

  private activatedRoute=inject(ActivatedRoute)

    ngOnInit(): void {
      //Reading Route Parameters using routerLink
   this.activatedRoute.paramMap.subscribe(params => {
    const id= params.get('id')
    //console.log(id)
    //API CALL
   })
  }
}
