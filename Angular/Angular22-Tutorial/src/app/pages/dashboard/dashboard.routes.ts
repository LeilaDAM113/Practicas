import { Orders } from './../orders/orders';
import { Settings } from './../settings/settings';
import { Profile } from './../profile/profile';
import { DashboardHome } from './../dashboard-home/dashboard-home';
import { Routes } from "@angular/router";
import { dashChildGuard } from '../../guards/dash-child-guard';
import { Dashboard } from './dashboard';
import { unsavedChangesGuard } from '../../guards/unsaved-changes-guard';

export const DASHBOARD_ROUTES: Routes = [
  {
    path: '', 
    component: Dashboard,
     canActivateChild : [dashChildGuard],
    children: [
      { path: '', redirectTo: 'dashboardhome', pathMatch: 'full' },
      { 
        path: 'dashboardhome', component: DashboardHome
      },
      { 
        path: 'profile', component: Profile
        , canDeactivate: [unsavedChangesGuard]
       
      },
      { 
        path: 'settings', //component: Settings
        loadComponent: () => import('../settings/settings').then(c => c.Settings) 
      },
      { 
        path: 'orders', //component: Orders
        loadComponent: () => import('../orders/orders').then(c => c.Orders) 
      }
    ]
  }
]