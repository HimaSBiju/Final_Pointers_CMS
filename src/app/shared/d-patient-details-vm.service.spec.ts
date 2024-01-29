import { TestBed } from '@angular/core/testing';

import { DPatientDetailsVMService } from './d-patient-details-vm.service';

describe('DPatientDetailsVMService', () => {
  let service: DPatientDetailsVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DPatientDetailsVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
