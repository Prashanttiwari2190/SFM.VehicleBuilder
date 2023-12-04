import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/core/services/vehicle.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IYear } from 'src/app/models/IYear';
import { IDivision } from 'src/app/models/IDevision';
import { IModel } from 'src/app/models/IModel';
import { ICabStyle, IExteriorColor, IStyleOptions } from 'src/app/models/IStyleOptions';
import { SubSink } from 'subsink';
import { IStyleFilters } from 'src/app/models/IStyleFilters';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit {
  subs = new SubSink();
  isLoading = false;
  years: IYear[] = [];
  selectedYear: number = 0;

  devisions: any[] = [];
  selectedMake: number = 0;

  models: IModel[] = [];
  selectedModel: number = 0;

  styleOptions: IStyleOptions;
  cabStyle: ICabStyle[] = [];
  exteriorColor: IExteriorColor[] = [];
  selectedExteriorColor: string;
  selectedCabStyle: number = 0;
  minWheelBase: number;
  maxWheelBase: number;
  minPriceLevel: number;
  maxPriceLevel: number;
  displayMessage: string;

  styleFilter: IStyleFilters;
  styles: IStyles[] = [];

  constructor(private service: VehicleService) { }

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
      this.models = models
    });
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

  loadStyleSearch() {
    this.isLoading = true;
    this.styleFilter = 
      {
      year: this.selectedYear,
      divisionId: this.selectedMake,
      modelId: this.selectedModel,
      exteriorColorId: this.selectedExteriorColor,
      cabStyleId: this.selectedCabStyle,
      minWheelBase: this.minWheelBase,
      maxWheelBase: this.maxWheelBase,
      minPriceLevel: this.minPriceLevel,
      maxPriceLevel: this.maxPriceLevel
    };
    this.service.getStyleSearch(this.styleFilter).subscribe(styles => {
      this.styles = styles;
      this.isLoading = false;
      if(this.styles.length == 0)
        this.displayMessage = "No vehicle style search information found for the selected criteria.....  Why don't you try something else:)";
      else
        this.displayMessage = "";
      console.log(this.styles);
    });


  }
}

