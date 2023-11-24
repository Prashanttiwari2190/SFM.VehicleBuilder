import { Component, OnInit } from '@angular/core';
import { VehicleService  } from 'src/app/core/services/vehicle.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IYear } from 'src/app/models/IYear';
import { IDivision } from 'src/app/models/IDevision';
import { IModel } from 'src/app/models/IModel';
import { ICabStyle, IExteriorColor, IStyleOptions } from 'src/app/models/IStyleOptions';
import { SubSink } from 'subsink';
import { IStyleFilters } from 'src/app/models/IStyleFilters';
import { IStyles } from 'src/app/models/IStyles';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit{
  subs = new SubSink();
  isLoading = false;
  years: IYear[] = [];
  selectedYear: number;

  devisions: any[] = [];
  selectedMake: number;

  models: IModel[] = [];
  selectedModel: number;

  styleOptions: IStyleOptions;
  cabStyle: ICabStyle[] = [];
  exteriorColor: IExteriorColor[] = [];
  selectedExteriorColor: string;
  selectedCabStyle: string;
  minWheelBase: number;
  maxWheelBase: number;
  minPriceLevel: number;
  maxPriceLevel: number;

  styleFilter: IStyleFilters;
  styles: IStyles[] = [];

  constructor(private service: VehicleService) {}

  ngOnInit() {
    this.loadYears();
    this.loadStyleOptions();
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

  loadStyleOptions() {
    this.service.getStyleOptions().subscribe(styleOptions => {
      this.cabStyle = styleOptions.cabStyle;
      this.exteriorColor = styleOptions.exteriorColor;
    });
  }

  onColorButtonClick(color: string) {
    this.selectedExteriorColor = color;
  }

  loadStyleSearch(){
    this.isLoading = true;
    this.styleFilter.year = this.selectedYear.toString();
    this.styleFilter.divisionId = this.selectedMake.toString();
    this.styleFilter.modelId = this.selectedModel.toString();
    this.styleFilter.exteriorColorId = this.selectedExteriorColor.toString();
    this.styleFilter.cabStyleId = this.selectedCabStyle.toString();
    this.styleFilter.minWheelBase= this.minWheelBase.toString();
    this.styleFilter.maxWheelBase= this.maxWheelBase.toString();
    this.styleFilter.minPriceLevel = this.minPriceLevel.toString();
    this.styleFilter.maxPriceLevel = this.maxPriceLevel.toString();
    this.service.getStyleSearch(this.styleFilter).subscribe(styles => {
      this.styles = styles;
      this.isLoading = false;
    })
  }
}

