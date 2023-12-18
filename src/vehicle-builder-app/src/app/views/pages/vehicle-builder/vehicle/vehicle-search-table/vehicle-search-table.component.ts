import { Component, Input, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnChanges } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';
import { ISearchStyleBodyType } from 'src/app/models/SearchStyle/ISearchStyleBodyType';
import { ISearchStyleModel } from 'src/app/models/SearchStyle/ISearchStyleModel';
import { ICabStyle, IExteriorColor } from 'src/app/models/IStyleOptions';
import { VehicleService } from 'src/app/core/services/vehicle.service';

import { map } from 'rxjs';
import { IModelConfigration } from 'src/app/models/SearchStyle/IModelConfigration';
import { IGenericColors } from 'src/app/models/SearchStyle/IGenericColors';
import { IWheelBase } from 'src/app/models/SearchStyle/IWheelBase';

@Component({
  selector: 'app-vehicle-search-table',
  templateUrl: './vehicle-search-table.component.html',
  styleUrls: ['./vehicle-search-table.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],

})
export class VehicleSearchTableComponent implements OnChanges {

  @ViewChild('outerSort', { static: true }) sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<ISearchStyleModel>>;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() dataSourceStyleSearch: IStyles[];

  dataSource: MatTableDataSource<IStyles>;
  styleSearchResultData: IStyles[] = [];
  columnsToDisplay = ['action', 'manufacturerModelCode', 'styleName', 'model', 'baseMsrp',];
  expandedElement: IStyles | null;

  cabStyle: ICabStyle[] = [];
  wheelBaseList: IWheelBase[] = [];
  genericColors: IGenericColors[] = [];
  selectedExteriorColor: string;
  selectedExteriorColorName: string;
  selectedCabStyle: string = "";
  selectedWheelBase: string = "";
  filteredStyleIds: number[] = [];
  styleConfig: IModelConfigration;
  secondlevleFilteredStyleIds: number[] = [];

  constructor(private cd: ChangeDetectorRef, private service: VehicleService) {
  }

  ngOnChanges() {
    this.loadResultData();
  }

  loadResultData() {
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch);
    this.dataSourceStyleSearch.forEach(e => {
      e.bodyTypes.forEach(e1 => {
        let idx = this.cabStyle.findIndex(elem => elem.bodyTypeId === e1.bodyTypeId)
        if (idx == -1)
          this.cabStyle.push(e1);
      })
    })

    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

  }

  dataSourceStyleSearchValid(dataSourceStyleSearch: IStyles[]): boolean {
    return typeof dataSourceStyleSearch != "undefined" && dataSourceStyleSearch != null && dataSourceStyleSearch.length > 0;
  }

  applyFilter(filterValue: string) {
    this.resetSecondLevelFilters();
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch);
    this.dataSource.filter = this.selectedCabStyle.trim().toLowerCase();

    this.dataSource.filteredData.forEach(item => {
      this.filteredStyleIds.push(item.styleId)
    });

    this.service.getStylesConfig(this.filteredStyleIds).subscribe(styleConfig => {
      this.styleConfig = styleConfig;
      this.genericColors = styleConfig.genericColors;
      this.wheelBaseList = styleConfig.wheelbase;
    });


  }

  onColorButtonClick(color: string, colorName: string) {
    this.selectedExteriorColor = color;
    this.selectedExteriorColorName = colorName;
    this.applySecondLevelFilter();
  }

  applySecondLevelFilter() {
    this.secondlevleFilteredStyleIds = this.getFilteredStyleIds(this.selectedExteriorColor, this.selectedWheelBase);
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch.filter(item =>
      this.secondlevleFilteredStyleIds.includes(item.styleId)
    ));
  }

  resetFilter() {
    this.selectedCabStyle = '';
    this.filteredStyleIds = [];
    this.selectedExteriorColor = "";
    this.selectedExteriorColorName = "";
    this.resetSecondLevelFilters();
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch);
  }

  resetSecondLevelFilters() {
    this.filteredStyleIds = [];
    this.secondlevleFilteredStyleIds = [];
    this.genericColors = [];
    this.wheelBaseList = [];
    this.styleConfig;
  }

  toggleRow(element: IStyles) {
    element ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();
    this.expandedElement = element;
  }

  formatDate(date: string) {
    return new Date(date).toLocaleDateString();
  }

  getFilteredStyleIds(color: string, wheelbase: string): number[] {
    const colorObject = this.styleConfig.genericColors.find(c => c.rgbValue === color);
    const wheelbaseObject = this.styleConfig.wheelbase.find(w => w.value === wheelbase);

    if (!colorObject && !wheelbase) {
      return [];
    }
    else {
      if (!wheelbaseObject && colorObject) {
        const commonStyleIds = colorObject.styleIds;
        return commonStyleIds;
      } else if (wheelbaseObject && !colorObject) {
        const commonStyleIds = wheelbaseObject.styleIds;
        return commonStyleIds;
      }
      else {
        if (colorObject && wheelbaseObject) {
          const commonStyleIds = colorObject.styleIds.filter(styleId => wheelbaseObject.styleIds.includes(styleId));
          return commonStyleIds;
        } else {
          return [];
        }
      }
    }


  }
}
