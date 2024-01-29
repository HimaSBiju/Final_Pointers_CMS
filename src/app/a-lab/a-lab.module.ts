import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ALabRoutingModule } from './a-lab-routing.module';
import { LabComponent } from './lab/lab.component';


@NgModule({
  declarations: [LabComponent],
  imports: [
    CommonModule,
    ALabRoutingModule
  ]
})
export class ALabModule { }
