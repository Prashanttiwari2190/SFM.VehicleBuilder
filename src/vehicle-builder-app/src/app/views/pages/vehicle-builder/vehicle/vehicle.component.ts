import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/core/services/vehicle.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IYear } from 'src/app/models/IYear';
import { IDivision } from 'src/app/models/IDevision';
import { IModel } from 'src/app/models/IModel';
import { IStyleOptions } from 'src/app/models/IStyleOptions';
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
  isYearSelected: boolean = true;

  devisions: any[] = [];
  selectedMake: number = 0;
  isMakeSelected: boolean = true;
  
  models: IModel[] = [];
  selectedModel: number = 0;
  isModelSelected : boolean = true;
  
  styleOptions: IStyleOptions;
  
  styleFilter: IStyleFilters;
  styles: IStyles[] = [];
  displayMessage: string;
  constructor(private service: VehicleService) { }

  ngOnInit() {
    this.loadYears();
    this.loadStyleOptions();
  }

  loadYears() {
    this.service.getYears().subscribe(years => {
      this.years = years;
      this.selectedMake= 0;
      this.selectedModel= 0;
    });
  }


  onYearChange() {
    this.service.getMakes(this.selectedYear).subscribe(devisions => {
      this.devisions = devisions;
      this.selectedMake= 0;
      this.styles = [];
    });
  }

  onMakeChange() {
    this.service.getModels(this.selectedYear, this.selectedMake).subscribe(models => {
      this.models = models;
      this.selectedModel= 0;
      this.styles = [];
    });
  }

  loadStyleOptions() {
    this.service.getStyleOptions().subscribe(styleOptions => {
    });
  }

 

  loadStyles() {
    this.isLoading = true;
    this.service.getStyles(this.selectedYear, this.selectedModel).subscribe(styles => {
      this.styles = styles;
      this.isLoading = false;
      console.log(this.styles);
    });
  }

  loadStyleSearch() {
    this.isLoading = true;
    if(this.selectedYear == 0){
      this.isYearSelected = false;
    } else {this.isYearSelected = true;}
    if(this.selectedMake == 0){
      this.isMakeSelected = false;
    } else {
      this.isMakeSelected = true;
    }

    if(this.selectedModel == 0){
      this.isModelSelected = false;
    } else {
      this.isModelSelected = true;
    }

    if(this.isYearSelected == true && this.isMakeSelected == true && this.isModelSelected == true){
      this.styleFilter =
        {
        year: this.selectedYear,
        divisionId: this.selectedMake,
        modelId: this.selectedModel,
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
}

