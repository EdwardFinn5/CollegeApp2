import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { ColAccountService } from '../_services/col-account.service';
import { ColUser } from '../_models/colUser';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private colAccountService: ColAccountService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    let currentColUser: ColUser;

    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => (currentColUser = colUser));
    if (currentColUser) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentColUser.token}`,
        },
      });
    }
    return next.handle(request);
  }
}
