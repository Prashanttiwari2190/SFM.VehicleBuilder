import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{

  @Input() vendorName: string = 'Sample Vendor';

  constructor(private auth: AuthService) { }
  
  ngOnInit(): void {
    this.auth.user$.subscribe(user => this.vendorName = user ? user['https://sfmpartnerportal.com/vendor_name'] : '');
  }

}
