import { TestBed } from '@angular/core/testing';

import { LabBillGenerationService } from './lab-bill-generation.service';

describe('LabBillGenerationService', () => {
  let service: LabBillGenerationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabBillGenerationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
