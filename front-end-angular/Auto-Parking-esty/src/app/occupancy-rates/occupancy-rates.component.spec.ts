import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OccupancyRatesComponent } from './occupancy-rates.component';

describe('OccupancyRatesComponent', () => {
  let component: OccupancyRatesComponent;
  let fixture: ComponentFixture<OccupancyRatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OccupancyRatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OccupancyRatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
