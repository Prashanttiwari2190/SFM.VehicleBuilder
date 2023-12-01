import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { IYear } from 'src/app/models/IYear';
import { IModel } from 'src/app/models/IModel';
import { environment } from 'src/environments/environment';
import { IDivision } from 'src/app/models/IDevision';
import { IStyleOptions } from 'src/app/models/IStyleOptions';
import { IStyleFilters } from 'src/app/models/IStyleFilters';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';
import { ICON_REGISTRY_PROVIDER } from '@angular/material/icon';
import { style } from '@angular/animations';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) {
  }

  
  getYears(): Observable<IYear[]> {
    return this.http.get<IYear[]>( environment.apiBaseUrl + `vehicle/year`);
  }

  getMakes(year: number): Observable<IDivision[]> {
    return this.http.get<IDivision[]>(environment.apiBaseUrl +`vehicle/make/${year}`);
  }


  getModels(year: number, make: number): Observable<IModel[]> {
    return this.http.get<IModel[]>(environment.apiBaseUrl + `vehicle/${year}/model/${make}`);
  }

  getStyleOptions(): Observable<IStyleOptions> {
    return this.http.get<IStyleOptions>(environment.apiBaseUrl + `vehicle/style-options`);
  }
  
  getStyleSearch(styleFilter: IStyleFilters): Observable<IStyles[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
  
    return this.http.post<IStyles[]>(environment.apiBaseUrl + 'vehicle/style-search', styleFilter, { headers })
      .pipe(
        map(styleRsults => {
          styleRsults
          return styleRsults;})
      );
  }}
