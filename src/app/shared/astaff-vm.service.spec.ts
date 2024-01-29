import { TestBed } from '@angular/core/testing';

import { AStaffVMService } from './astaff-vm.service';

describe('AStaffVMService', () => {
  let service: AStaffVMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AStaffVMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
