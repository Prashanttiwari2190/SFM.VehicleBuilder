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
      domain: 'sfm-vehicle-builder.us.auth0.com',
      clientId: 'abJ3fa9jFg0jL4xy2f9Qzi3WAsPdx56j',
      cacheLocation: 'localstorage',
      audience: 'https://vehicle-builder.sewelldevteam.com',
      httpInterceptor: {
        allowedList: [
          {
            uri: 'https://test.sfmdev.com:5031/api/*',
            tokenOptions: {
              audience: 'https://vehicle-builder.sewelldevteam.com'
            },
          },
          {
            uri: 'https://vehicle-builder.sewelldevteam.com/api/*',
            tokenOptions: {
              audience: 'https://vehicle-builder.sewelldevteam.com'
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
