import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryParkingComponent } from './history-parking.component';

describe('HistoryParkingComponent', () => {
  let component: HistoryParkingComponent;
  let fixture: ComponentFixture<HistoryParkingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoryParkingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryParkingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
