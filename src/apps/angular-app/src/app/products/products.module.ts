import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products.routing.module';
import { ProductsComponent } from './products.component';
import { ProductsService } from './products.service';

@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [   
    ProductsRoutingModule
  ],
  providers: [
    ProductsService
  ],
  bootstrap: [ProductsComponent]
})
export class ProductsModule { }