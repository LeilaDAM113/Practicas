import { Routes } from '@angular/router';
import { ProductsComponent } from './pages/products/products.component'; 
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

export const routes: Routes = [
 
  { path: 'products', component: ProductsComponent },
  {path: 'about-us', component: AboutUsComponent},
  {path: '', redirectTo: '/products', pathMatch:'full'},
  {path: '**', component: NotFoundComponent}
];