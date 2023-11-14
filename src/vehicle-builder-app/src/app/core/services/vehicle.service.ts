import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { IYear } from 'src/app/models/IYear';
import { IModel } from 'src/app/models/IModel';
import { environment } from 'src/environments/environment';
import { IDivision } from 'src/app/models/IDevision';

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
  
}
