import { Component, OnInit } from '@angular/core';
import { VehicleService  } from 'src/app/core/services/vehicle.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IYear } from 'src/app/models/IYear';
import { IDivision } from 'src/app/models/IDevision';
import { IModel } from 'src/app/models/IModel';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit{
  subs = new SubSink();
  years: IYear[] = [];
  selectedYear: number;

  devisions: any[] = [];
  selectedMake: number;

  models: IModel[] = [];
  selectedModel: number;

  constructor(private service: VehicleService) {}

  ngOnInit() {
    this.loadYears();
  }

  loadYears() {
    this.service.getYears().subscribe(years => {
      this.years = years;
    });
  }

  onYearChange() {
    this.service.getMakes(this.selectedYear).subscribe(devisions => {
      this.devisions = devisions;
    });
  }

  onMakeChange() {
    this.service.getModels(this.selectedYear, this.selectedMake).subscribe(models => {
      this.models =  models});
  }
}
