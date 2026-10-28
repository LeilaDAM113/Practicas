import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { About } from './pages/about/about';
import { Contact } from './pages/contact/contact';
import { Products } from './pages/products/products';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { PageNotFound } from './pages/page-not-found/page-not-found';
import { ProductDetails } from './pages/product-details/product-details';
import { Dashboard } from './pages/dashboard/dashboard';
import { DashboardHome } from './pages/dashboard-home/dashboard-home';
import { Profile } from './pages/profile/profile';
import { Settings } from './pages/settings/settings';
import { Orders } from './pages/orders/orders';
import { authGuard } from './guards/auth-guard';
import { dashboardMatchGuard } from './guards/dashboard-match-guard';
import { Signal } from './pages/signal/signal';
import { Parent } from './pages/parent/parent';

export const routes: Routes = [
  { path: '', redirectTo: '/pages/parent', pathMatch: 'full' },
  { path: 'pages/parent' , component: Parent}, 
  {path: 'pages/signal', component: Signal},
  { path: 'pages/login', component: Login },
  { path: 'pages/home', component: Home },
  { path: 'pages/register', component: Register },
  { path: 'pages/product-details/:id', component: ProductDetails }, 
  { 
    path: 'pages/about', //component: About
    loadComponent: () => import('./pages/about/about').then(c => c.About),
    
  },
  { 
    path: 'pages/contact', //component: Contact
    loadComponent: () => import('./pages/contact/contact').then(c => c.Contact) 
  },
  { 
    path: 'pages/products', //component: Products
    loadComponent: () => import('./pages/products/products').then(c => c.Products) 
  },
  {
    path: 'pages/dashboard',
    //component: Dashboard,
    //canActivate: [authGuard],
    canMatch: [dashboardMatchGuard],
    loadChildren: () => import('./pages/dashboard/dashboard.routes').then(r => r.DASHBOARD_ROUTES)
    // children: [
    //   { path: '', redirectTo: 'dashboardhome', pathMatch: 'full' },
    //   { path: 'dashboardhome', component: DashboardHome },
    //   { path: 'profile', component: Profile },
    //   { path: 'settings', component: Settings },
    //   { path: 'orders', component: Orders }
    // ]
  },
  { path: '**', component: PageNotFound }
];
