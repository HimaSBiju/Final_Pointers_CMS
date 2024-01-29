import { Injectable } from '@angular/core';
import { LLabReportVM } from './l-lab-report-vm';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import{environment} from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LLabReportVMService {
  lLabReportVM : LLabReportVM[];
  formData =new LLabReportVM()

  constructor(private httpClient:HttpClient) { }

  BindListReport()
  {
    this.httpClient.get(environment.apiUrl + "/api/LlabTests/List")
    .toPromise().then(response =>{
      this.lLabReportVM=response as LLabReportVM[];
    console.log(this.lLabReportVM);}
   );
}

// insertLabReport(lab: LLabReportVM):Observable<any>{
//   return this.httpClient.post(environment.apiUrl +"/api/LabReport",lab)
//   }
  // ... other lab reports
  

}
