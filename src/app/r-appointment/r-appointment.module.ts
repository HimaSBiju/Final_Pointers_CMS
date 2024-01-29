import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RAppointmentRoutingModule } from './r-appointment-routing.module';
import { AppointmentComponent } from './appointment/appointment.component';


@NgModule({
  declarations: [AppointmentComponent],
  imports: [
    CommonModule,
    RAppointmentRoutingModule
  ]
})
export class RAppointmentModule { }
