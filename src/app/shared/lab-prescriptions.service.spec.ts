import { TestBed } from '@angular/core/testing';

import { LabPrescriptionsService } from './lab-prescriptions.service';

describe('LabPrescriptionsService', () => {
  let service: LabPrescriptionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabPrescriptionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
