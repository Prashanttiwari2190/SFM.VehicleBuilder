import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSearchTableComponent } from './vehicle-search-table.component';

describe('VehicleSearchTableComponent', () => {
  let component: VehicleSearchTableComponent;
  let fixture: ComponentFixture<VehicleSearchTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleSearchTableComponent]
    });
    fixture = TestBed.createComponent(VehicleSearchTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
