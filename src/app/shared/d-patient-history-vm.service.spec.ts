import { TestBed } from '@angular/core/testing';

import { DPatientHistoryVMService } from './d-patient-history-vm.service';

describe('DPatientHistoryVMService', () => {
  let service: DPatientHistoryVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DPatientHistoryVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
