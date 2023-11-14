import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleBuilderComponent } from './vehicle-builder.component';

describe('VehicleBuilderComponent', () => {
  let component: VehicleBuilderComponent;
  let fixture: ComponentFixture<VehicleBuilderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleBuilderComponent]
    });
    fixture = TestBed.createComponent(VehicleBuilderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
