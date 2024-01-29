import { TestBed } from '@angular/core/testing';

import { DDiagnosisVMService } from './d-diagnosis-vm.service';

describe('DDiagnosisVMService', () => {
  let service: DDiagnosisVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DDiagnosisVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
