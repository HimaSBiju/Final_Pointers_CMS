import { TestBed } from '@angular/core/testing';

import { LLabTestsVMService } from './l-lab-tests-vm.service';

describe('LLabTestsVMService', () => {
  let service: LLabTestsVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LLabTestsVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
