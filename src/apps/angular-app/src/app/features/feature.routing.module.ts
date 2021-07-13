import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {FeaturesComponent} from './features.component';
import {FeatureDeatilsComponent} from './feature-details/feature-details.component';


const routes: Routes = [
    {path:'features', component: FeaturesComponent},
    {path:'feature-details', component: FeatureDeatilsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }