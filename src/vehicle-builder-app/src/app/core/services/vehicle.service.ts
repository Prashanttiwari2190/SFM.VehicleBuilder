import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { IYear } from 'src/app/models/IYear';
import { IModel } from 'src/app/models/IModel';
import { IDivision } from 'src/app/models/IDevision';
import { IStyleOptions } from 'src/app/models/IStyleOptions';
import { IStyleFilters } from 'src/app/models/IStyleFilters';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';
import { ICON_REGISTRY_PROVIDER } from '@angular/material/icon';
import { style } from '@angular/animations';
import { IModelConfigration } from 'src/app/models/SearchStyle/IModelConfigration';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) {
  }

  
  getYears(): Observable<IYear[]> {
    return this.http.get<IYear[]>(`vehicle/year`);
  }

  getMakes(year: number): Observable<IDivision[]> {
    return this.http.get<IDivision[]>(`vehicle/make/${year}`);
  }


  getModels(year: number, make: number): Observable<IModel[]> {
    return this.http.get<IModel[]>(`vehicle/${year}/model/${make}`);
  }

  getStyleOptions(): Observable<IStyleOptions> {
    return this.http.get<IStyleOptions>(`vehicle/style-options`);
  }
  
  getStyleSearch(styleFilter: IStyleFilters): Observable<IStyles[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
  
    return this.http.post<IStyles[]>('vehicle/style-search', styleFilter, { headers })
      .pipe(
        map(styleRsults => {
          styleRsults
          return styleRsults;})
      );
  }

  getStylesConfig(styleids: number[]): Observable<IModelConfigration> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
  
    return this.http.post<IModelConfigration>('vehicle/styles-config', styleids, { headers })
      .pipe(
        map(stylesConfigResult => {
          stylesConfigResult
          return stylesConfigResult;})
      );
  }

}
