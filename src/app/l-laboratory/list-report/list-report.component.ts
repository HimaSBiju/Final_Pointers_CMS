import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import{LLabReportVMService} from 'src/app/shared/l-lab-report-vm.service'
import { LLabTestsVMService } from 'src/app/shared/l-lab-tests-vm.service';

@Component({
  selector: 'app-list-report',
  templateUrl: './list-report.component.html',
  styleUrls: ['./list-report.component.scss']
})
export class ListReportComponent implements OnInit {
  data: any;

  constructor(public lLabReportVMService:LLabReportVMService,private router : Router,
    public lLabTestsVMService:LLabTestsVMService) { }

  ngOnInit(): void {
    console.log("welcome to life cycle hook");
    this.lLabReportVMService.BindListReport();
  }
  
  generateBill() {
    // Assuming you want to pre-fill some fields in labreportService.formData_L
    
    // Navigate to the lab report form with the price
    this.router.navigate(['/l-laboratory/bill'])
  }
  ViewReport(lab:any){
    this.lLabReportVMService.formData.ReportId = lab.ReportId;
     this.lLabReportVMService.formData.ReportDate = lab.ReportDate;
     this.lLabReportVMService.formData.PatientName = lab.PatientName;
     this.lLabReportVMService.formData.TestName = lab.TestName;
     this.lLabReportVMService.formData.LowRange = lab.LowRange;
     this.lLabReportVMService.formData.HighRange = lab.HighRange;
     this.lLabReportVMService.formData.TestResult = lab.TestResult;
     this.lLabReportVMService.formData.Remarks = lab.Remarks;
     
    this.router.navigate(['/l-laboratory/view',lab])

  }



  

}
