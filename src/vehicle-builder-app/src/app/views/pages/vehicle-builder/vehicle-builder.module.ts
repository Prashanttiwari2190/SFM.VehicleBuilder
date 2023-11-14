import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { VehicleBuilderComponent } from './vehicle-builder.component';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import { VehicleComponent } from './vehicle/vehicle.component';
import { VehicleService } from 'src/app/core/services/vehicle.service';
import { NgbAccordionModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  {
    path: '',
    component: VehicleBuilderComponent
  }
]


@NgModule({
  declarations: [VehicleBuilderComponent, VehicleComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule, MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    NgbDropdownModule,
    NgbAccordionModule,
  ],
  providers: [VehicleService]
})
export class VehicleBuilderModule {  
  

}
