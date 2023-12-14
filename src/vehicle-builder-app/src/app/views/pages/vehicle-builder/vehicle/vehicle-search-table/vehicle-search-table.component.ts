import { Component, Input, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnChanges } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';
import { ISearchStyleBodyType } from 'src/app/models/SearchStyle/ISearchStyleBodyType';
import { ISearchStyleModel } from 'src/app/models/SearchStyle/ISearchStyleModel';
import { ICabStyle, IExteriorColor } from 'src/app/models/IStyleOptions';

import { map } from 'rxjs';

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
export class VehicleSearchTableComponent implements OnChanges  {

  @ViewChild('outerSort', { static: true }) sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<ISearchStyleModel>>;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() dataSourceStyleSearch: IStyles[];

  dataSource: MatTableDataSource<IStyles>;
  styleSearchResultData: IStyles[] = [];
  columnsToDisplay = ['action','manufacturerModelCode','styleName','model','baseMsrp',];
  expandedElement: IStyles | null;
  
  cabStyle: ICabStyle[] = [];
  wheelBaseList: any[] = [];
  exteriorColor: IExteriorColor[] = [];
  selectedExteriorColor: string;
  selectedCabStyle: string = "";
  selectedWheelBase: number = 0;
  minWheelBase: number;
  maxWheelBase: number;
  minPriceLevel: number;
  maxPriceLevel: number;
  

  
  constructor(private cd: ChangeDetectorRef) { 
   }
  
  ngOnChanges() {
    this.loadResultData();
  }

  loadResultData(){
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch);
    this.dataSourceStyleSearch.forEach(e=> {
      e.bodyTypes.forEach(e1 => {
        let idx = this.cabStyle.findIndex(elem => elem.bodyTypeId === e1.bodyTypeId)
        if(idx == -1)
            this.cabStyle.push(e1);
      })
    })

    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

  }

  dataSourceStyleSearchValid(dataSourceStyleSearch : IStyles[]) : boolean {
    return typeof dataSourceStyleSearch != "undefined" && dataSourceStyleSearch != null && dataSourceStyleSearch.length > 0;
  }

   applyFilter(filterValue : string) {
     this.dataSource.filter = this.selectedCabStyle.trim().toLowerCase();
   }

   resetFilter() {
    this.selectedCabStyle = '';
    this.applyFilter('');
  }

  onColorButtonClick(color: string) {
    this.selectedExteriorColor = color;
  }

  toggleRow(element: IStyles) {
    element ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();
    this.expandedElement = element;
  }

  formatDate(date: string) {
    return new Date(date).toLocaleDateString();
  }
  
}
