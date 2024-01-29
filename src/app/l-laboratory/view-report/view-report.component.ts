import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LLabReportVMService } from 'src/app/shared/l-lab-report-vm.service';
import { LLabTestsVMService } from 'src/app/shared/l-lab-tests-vm.service';
import{LabReportGenerationService} from 'src/app/shared/lab-report-generation.service'

@Component({
  selector: 'app-view-report',
  templateUrl: './view-report.component.html',
  styleUrls: ['./view-report.component.scss']
})
export class ViewReportComponent implements OnInit {

  constructor(
    public lLabReportVMService: LLabReportVMService,  private router : Router,
    public labtestvmService: LLabTestsVMService,public labReportGenerationService:LabReportGenerationService) { }

  ngOnInit(): void {
    console.log('welcome to life cycle hook');
    this.lLabReportVMService.BindListReport();
  }
  generateBill() {
  // Assuming you want to pre-fill some fields in labreportService.formData_L
     

  // Navigate to the lab report form
  this.router.navigate(['/l-laboratory/bill'])
  }
 


printLabReport() {
  // You can implement the print logic here
  alert('Please connect the printer.');
  window.print();
}
goBack() {
  this.router.navigate(['/l-laboratory/report']);
  }

}
