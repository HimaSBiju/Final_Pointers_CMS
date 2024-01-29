import { Injectable } from '@angular/core';
import { LGetIDVM } from './l-get-idvm';

@Injectable({
  providedIn: 'root'
})
export class LGetIDVMService {

  constructor() { }
  lGetIDVM:LGetIDVM[];
}
