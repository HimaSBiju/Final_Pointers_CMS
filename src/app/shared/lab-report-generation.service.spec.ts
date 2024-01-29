import { TestBed } from '@angular/core/testing';

import { LabReportGenerationService } from './lab-report-generation.service';

describe('LabReportGenerationService', () => {
  let service: LabReportGenerationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabReportGenerationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
