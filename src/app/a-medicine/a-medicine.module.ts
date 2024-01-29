import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AMedicineRoutingModule } from './a-medicine-routing.module';
import { MedicineComponent } from './medicine/medicine.component';


@NgModule({
  declarations: [MedicineComponent],
  imports: [
    CommonModule,
    AMedicineRoutingModule
  ]
})
export class AMedicineModule { }
