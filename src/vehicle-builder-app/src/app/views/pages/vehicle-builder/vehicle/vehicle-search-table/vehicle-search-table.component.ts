import { Component, Input, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnChanges } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { IStyles } from 'src/app/models/SearchStyle/IStyles';
import { ISearchStyleBodyType } from 'src/app/models/SearchStyle/ISearchStyleBodyType';
import { ISearchStyleModel } from 'src/app/models/SearchStyle/ISearchStyleModel';
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
  columnsToDisplay = ['action','styleName','baseMsrp','baseInvoice','marketClassName'];
  columnsToDisplayHeader = ['Action','Style Name', 'Base Msrp','Base Invoice', 'Market ClassName'];
  innerDisplayedColumns = ['modelYear','divisionName','modelName'];
  expandedElement: IStyles | null;
  noData: any;
  
  constructor(private cd: ChangeDetectorRef) { 
  }
  
  ngOnChanges() {
    this.loadResultData();
  }

  loadResultData(){
    this.dataSource = new MatTableDataSource(this.dataSourceStyleSearch);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    //this.noData = this.dataSource.data.length;// this.dataSource.connect().pipe(map(data => data.length === 0));
  }

  dataSourceStyleSearchValid(dataSourceStyleSearch : IStyles[]) : boolean {
    return typeof dataSourceStyleSearch != "undefined" && dataSourceStyleSearch != null && dataSourceStyleSearch.length > 0;
  }

  // applyFilter(filterValue: string) {
  //   this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<ISearchStyleBodyType>).filter = filterValue.trim().toLowerCase());
  // }

  toggleRow(element: IStyles) {
    element ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();
    this.expandedElement = element;
  }

  formatDate(date: string) {
    return new Date(date).toLocaleDateString();
  }
  
}
