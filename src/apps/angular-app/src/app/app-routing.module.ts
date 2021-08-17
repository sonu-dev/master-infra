import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.cmponent';
import { AuthGuardService} from './shared/services/auth-gaurd.service';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuardService] },
  {
    path:'products',  
    loadChildren: () => import('./products/products.module').then(m => m.ProductsModule),
    canActivate: [AuthGuardService]
  },  
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
