import { TestBed } from '@angular/core/testing';

import { LGetIDVMService } from './l-get-idvm.service';

describe('LGetIDVMService', () => {
  let service: LGetIDVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LGetIDVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
