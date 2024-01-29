import { TestBed } from '@angular/core/testing';

import { RBillViewModelService } from './r-bill-view-model.service';

describe('RBillViewModelService', () => {
  let service: RBillViewModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RBillViewModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
