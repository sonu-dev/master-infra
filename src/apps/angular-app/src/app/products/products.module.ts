import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products.routing.module';
import { ProductsComponent } from './products.component';

@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [   
    ProductsRoutingModule
  ],
  providers: [],
  bootstrap: [ProductsComponent]
})
export class FeaturesModule { }