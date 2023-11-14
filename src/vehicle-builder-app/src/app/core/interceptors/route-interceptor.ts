import { Location } from '@angular/common';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';

/*
 * Add the Authentication token to the request.
 */
@Injectable()
export class RouteInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const modifiedReq = req.clone({
      url: this.getFullUrl(req.url)
    });

    return next.handle(modifiedReq);
  }

  private getFullUrl(url: string) {
    return url.slice(0, 6) === 'https:' || url.slice(0, 5) === 'http:'
      ? url
      : this.fullUrl(url);
  }

  public getBaseUrl(): string {
    return environment.apiBaseUrl;
  }

  public fullUrl(partial: string): string {
    const result = [this.getBaseUrl(), partial].reduce((base, part) =>
      Location.joinWithSlash(base, part)
    );
    return result;
  }
}