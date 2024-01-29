import { Injectable } from '@angular/core';
import { LabReportGeneration } from './lab-report-generation';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LabReportGenerationService {

  labreportgeneration: LabReportGeneration[];
  formData:LabReportGeneration =new LabReportGeneration();
  constructor(private httpClient:HttpClient) { }

   //Insert the labreport
   insertLabReport(lab: LabReportGeneration):Observable<any>{
    return this.httpClient.post(environment.apiUrl +"/api/LlabTests",lab)
  } 

}
