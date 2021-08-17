import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProductsComponent} from './products.component';
import {ProductDeatilsComponent} from './product-details/product-details.component';


const routes: Routes = [
    {path:'', component: ProductsComponent},
    {path:'product-details', component: ProductDeatilsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }