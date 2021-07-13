import { NgModule } from '@angular/core';

import { FeaturesRoutingModule } from './feature.routing.module';
import { FeaturesComponent } from './features.component';

@NgModule({
  declarations: [
    FeaturesComponent
  ],
  imports: [   
    FeaturesRoutingModule
  ],
  providers: [],
  bootstrap: [FeaturesComponent]
})
export class FeaturesModule { }