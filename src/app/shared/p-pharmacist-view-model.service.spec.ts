import { TestBed } from '@angular/core/testing';

import { PPharmacistViewModelService } from './p-pharmacist-view-model.service';

describe('PPharmacistViewModelService', () => {
  let service: PPharmacistViewModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PPharmacistViewModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
