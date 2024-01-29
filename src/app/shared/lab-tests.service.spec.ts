import { TestBed } from '@angular/core/testing';

import { LabTestsService } from './lab-tests.service';

describe('LabTestsService', () => {
  let service: LabTestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabTestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
