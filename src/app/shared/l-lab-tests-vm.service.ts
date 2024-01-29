import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import{environment} from 'src/environments/environment';
import{LLabTestsVM} from './l-lab-tests-vm';

@Injectable({
  providedIn: 'root'
})
export class LLabTestsVMService {
  labtestvm:LLabTestsVM[];

  formData: LLabTestsVM=new LLabTestsVM();



  constructor(private httpClient:HttpClient) { }
  BindListLabTestPrec()
  {
    this.httpClient.get(environment.apiUrl + "/api/LlabTests")
    .toPromise().then(response =>{
      this.labtestvm=response as LLabTestsVM[];}
   );
}
}
