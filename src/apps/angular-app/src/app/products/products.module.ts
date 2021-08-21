import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products.routing.module';
import { ProductsComponent } from './products.component';
import { ProductsService } from './products.service';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [    
    CommonModule, 
    ProductsRoutingModule   
  ],
  providers: [
    ProductsService
  ],
  bootstrap: [ProductsComponent]
})
export class ProductsModule { }