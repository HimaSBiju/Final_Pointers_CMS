import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import{LLabTestsVMService} from 'src/app/shared/l-lab-tests-vm.service';

@Component({
  selector: 'app-list-labprec',
  templateUrl: './list-labprec.component.html',
  styleUrls: ['./list-labprec.component.scss']
})
export class ListLabprecComponent implements OnInit {

  constructor(public lLabTestsVMService:LLabTestsVMService,
    private router : Router) { }

  ngOnInit(): void {
    console.log("welcome to life cycle hook");
    this.lLabTestsVMService.BindListLabTestPrec();
  }
  goBack() {
    this.router.navigate(['/laboratory/']);
}
generateReport(lab:any) {
  // Assuming you want to pre-fill some fields in labreportService.formData_L
  this.lLabTestsVMService.formData.AppointmentId = lab.AppointmentId;
  this.lLabTestsVMService.formData.PatientName = lab.PatientName;
  this.lLabTestsVMService.formData.DoctorName = lab.DoctorName;
  this.lLabTestsVMService.formData.TestName = lab.TestName;

// Navigate to the lab report form
this.router.navigate(['/l-laboratory/add',lab]);
}




}
