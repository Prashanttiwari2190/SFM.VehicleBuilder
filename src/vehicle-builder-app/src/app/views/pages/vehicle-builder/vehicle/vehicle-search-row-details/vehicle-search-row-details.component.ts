import { Component, Input } from '@angular/core';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';

@Component({
  selector: 'app-vehicle-search-row-details',
  templateUrl: './vehicle-search-row-details.component.html',
  styleUrls: ['./vehicle-search-row-details.component.scss']
})
export class VehicleSearchRowDetailsComponent {

  @Input() selectedElementStyleSearch: IStyles;
}
