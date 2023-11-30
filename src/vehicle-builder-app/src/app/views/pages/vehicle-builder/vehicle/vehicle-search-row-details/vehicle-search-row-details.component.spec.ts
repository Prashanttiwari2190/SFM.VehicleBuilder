import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSearchRowDetailsComponent } from './vehicle-search-row-details.component';

describe('VehicleSearchRowDetailsComponent', () => {
  let component: VehicleSearchRowDetailsComponent;
  let fixture: ComponentFixture<VehicleSearchRowDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleSearchRowDetailsComponent]
    });
    fixture = TestBed.createComponent(VehicleSearchRowDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
