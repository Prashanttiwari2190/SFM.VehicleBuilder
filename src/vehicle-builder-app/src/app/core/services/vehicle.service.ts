import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { IYear } from 'src/app/models/IYear';
import { IModel } from 'src/app/models/IModel';
import { IDivision } from 'src/app/models/IDevision';
import { IStyleOptions } from 'src/app/models/IStyleOptions';
import { IStyleFilters } from 'src/app/models/IStyleFilters';
import { IStyles } from 'src/app/models/IStyles';

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
    return this.http.get<IStyles[]>(`style-search/${styleFilter}`);
  }
}
