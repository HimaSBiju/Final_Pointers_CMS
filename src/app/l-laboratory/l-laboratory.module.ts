import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LLaboratoryRoutingModule } from './l-laboratory-routing.module';
import { LaboratoryComponent } from './laboratory/laboratory.component';
import { ListLabprecComponent } from './list-labprec/list-labprec.component';
import { AddReportComponent } from './add-report/add-report.component';
import { ListReportComponent } from './list-report/list-report.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ViewReportComponent } from './view-report/view-report.component';
import { BillComponent } from './bill/bill.component';



@NgModule({
  declarations: [LaboratoryComponent, ListLabprecComponent, AddReportComponent, ListReportComponent, ViewReportComponent, BillComponent, 
  ],
  imports: [
    CommonModule,
    LLaboratoryRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class LLaboratoryModule { }
