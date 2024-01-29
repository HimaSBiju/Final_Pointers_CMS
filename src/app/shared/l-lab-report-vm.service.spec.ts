import { TestBed } from '@angular/core/testing';

import { LLabReportVMService } from './l-lab-report-vm.service';

describe('LLabReportVMService', () => {
  let service: LLabReportVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LLabReportVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
