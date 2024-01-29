import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import{ListLabprecComponent} from 'src/app/l-laboratory/list-labprec/list-labprec.component'
import { ListReportComponent } from './list-report/list-report.component';
import { AddReportComponent } from './add-report/add-report.component';
import { ViewReportComponent } from './view-report/view-report.component';
import { BillComponent } from './bill/bill.component';

const routes: Routes = [
  {path:'list',component:ListLabprecComponent},
  {path:'report',component:ListReportComponent},
  {path:'add',component:AddReportComponent},
  {path:'view',component:ViewReportComponent},
  {path:'bill',component:BillComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LLaboratoryRoutingModule { }
