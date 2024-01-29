import { TestBed } from '@angular/core/testing';

import { ConsultationBillService } from './consultation-bill.service';

describe('ConsultationBillService', () => {
  let service: ConsultationBillService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsultationBillService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
