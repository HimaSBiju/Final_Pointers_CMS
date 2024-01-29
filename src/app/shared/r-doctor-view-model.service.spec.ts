import { TestBed } from '@angular/core/testing';

import { RDoctorViewModelService } from './r-doctor-view-model.service';

describe('RDoctorViewModelService', () => {
  let service: RDoctorViewModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RDoctorViewModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
