import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AStaffRoutingModule } from './a-staff-routing.module';
import { StaffComponent } from './staff/staff.component';


@NgModule({
  declarations: [StaffComponent],
  imports: [
    CommonModule,
    AStaffRoutingModule
  ]
})
export class AStaffModule { }
