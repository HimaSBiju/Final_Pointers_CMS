import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LLabTestsVMService } from 'src/app/shared/l-lab-tests-vm.service';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.scss']
})
export class BillComponent implements OnInit {

  
  constructor(public lLabTestsVMService:LLabTestsVMService,private router : Router) { }

  ngOnInit():void {
   
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
