import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DDoctorRoutingModule } from './d-doctor-routing.module';
import { DoctorComponent } from './doctor/doctor.component';


@NgModule({
  declarations: [DoctorComponent],
  imports: [
    CommonModule,
    DDoctorRoutingModule
  ]
})
export class DDoctorModule { }
