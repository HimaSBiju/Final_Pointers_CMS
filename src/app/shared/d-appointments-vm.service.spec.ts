import { TestBed } from '@angular/core/testing';

import { DAppointmentsVMService } from './d-appointments-vm.service';

describe('DAppointmentsVMService', () => {
  let service: DAppointmentsVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DAppointmentsVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
