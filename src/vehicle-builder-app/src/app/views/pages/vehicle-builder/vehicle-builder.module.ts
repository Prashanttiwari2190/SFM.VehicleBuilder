import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { VehicleBuilderComponent } from './vehicle-builder.component';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatStepperModule } from '@angular/material/stepper';
import { MatIconModule } from '@angular/material/icon';
import { VehicleComponent } from './vehicle/vehicle.component';
import { VehicleService } from 'src/app/core/services/vehicle.service';
import { NgbAccordionModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { VehicleSearchTableComponent } from './vehicle/vehicle-search-table/vehicle-search-table.component';
import { VehicleSearchRowDetailsComponent } from './vehicle/vehicle-search-row-details/vehicle-search-row-details.component';

const routes: Routes = [
  {
    path: '',
    component: VehicleBuilderComponent
  }
]


@NgModule({
  declarations: [VehicleBuilderComponent, VehicleComponent, VehicleSearchTableComponent, VehicleSearchRowDetailsComponent],
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
    MatTableModule,
    MatIconModule,
  ],
  exports: [MatTableModule],
  providers: [VehicleService]
})
export class VehicleBuilderModule {


}
