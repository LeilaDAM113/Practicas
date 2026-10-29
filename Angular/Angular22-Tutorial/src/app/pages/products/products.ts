import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Shopping } from '../../Services/shopping';

@Component({
  imports: [RouterLink],
  selector: 'app-products',
  styleUrl: './products.css',
  templateUrl: './products.html',
})
export class Products implements OnInit {
 protected shoppingService= inject(Shopping)
 addProducts(){
  this.shoppingService.addToCart()
 }

  // private router = inject(Router);
  // private activatedRoute = inject(ActivatedRoute);

  // passing the Route Parameters using navigate()
  //   viewDetails(productId:number){
  //  this.router.navigate(['/pages/product-details', productId]);
  //    console.log(productId)
  //   }

  // Reading Query parameters using RouterLink
  ngOnInit(): void {
    // this.activatedRoute.queryParamMap.subscribe(params => {
    //     const category = params.get('category')
    //     const sort = params.get('sort')
    //     console.log(category)
    //     console.log(sort)
    //    })
  }

  // passing the Query Parameters using navigate()
  viewDetails(category: string) {
    // this.router.navigate(['/pages/products'], {
    //   queryParams: {
    //     category: category
    //   }
    // });
    // console.log(category);
  }
}
