import { TestBed } from '@angular/core/testing';

import { RAppointmentViewModelService } from './r-appointment-view-model.service';

describe('RAppointmentViewModelService', () => {
  let service: RAppointmentViewModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RAppointmentViewModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
