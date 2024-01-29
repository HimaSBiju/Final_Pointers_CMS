import { TestBed } from '@angular/core/testing';

import { MedicinePrescriptionsService } from './medicine-prescriptions.service';

describe('MedicinePrescriptionsService', () => {
  let service: MedicinePrescriptionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicinePrescriptionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
