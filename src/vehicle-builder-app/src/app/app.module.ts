import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './views/layout/layout.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouteInterceptor } from './core/interceptors/route-interceptor';
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule,
    AuthModule.forRoot({
      domain: 'sfm-vehicle-test.us.auth0.com',
      clientId: '8vXtQCL7QPQVD0LvtJgn4e8eX4IbtoOL',
      cacheLocation: 'localstorage',
      audience: 'https://www.sfmdev.com',
      httpInterceptor: {
        allowedList: [
          {
            uri: 'https://test.sfmdev.com:5031/api/*',
            tokenOptions: {
              audience: 'https://www.sfmdev.com'
            },
          }
        ]
      }
    }),
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: RouteInterceptor,
    multi: true
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthHttpInterceptor,
    multi: true
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
