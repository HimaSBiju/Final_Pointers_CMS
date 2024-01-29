import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListLabprecComponent } from './list-labprec.component';

describe('ListLabprecComponent', () => {
  let component: ListLabprecComponent;
  let fixture: ComponentFixture<ListLabprecComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListLabprecComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListLabprecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
