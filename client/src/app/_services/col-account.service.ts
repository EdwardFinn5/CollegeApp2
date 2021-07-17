import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ColUser } from '../_models/colUser';

@Injectable({
  providedIn: 'root',
})
export class ColAccountService {
  baseUrl = environment.apiUrl;
  private currentColUserSource = new ReplaySubject<ColUser>(1);
  currentColUser$ = this.currentColUserSource.asObservable();
  colUserType: string;
  firstName: string;

  constructor(private http: HttpClient) {}

  colLogin(model: any) {
    return this.http.post(this.baseUrl + 'colAccount/colLogin', model).pipe(
      map((response: ColUser) => {
        const colUser = response;
        if (colUser) {
          this.setCurrentColUser(colUser);
          this.colUserType = colUser.colUserType;
          localStorage.setItem('colUser', JSON.stringify(colUser));
          this.currentColUserSource.next(colUser);
        }
      })
    );
  }

  collegeRegister(model: any) {
    return this.http
      .post(this.baseUrl + 'colaccount/collegeregister', model)
      .pipe(
        map((colUser: ColUser) => {
          if (colUser) {
            colUser.colUserType = 'College';
            this.setCurrentColUser(colUser);
            // this.currentColUserSource.next(colUser);
            // this.colUserType = colUser.colUserType;
          }
          // return colUser;
        })
      );
  }

  hsRegister(model: any) {
    return this.http.post(this.baseUrl + 'colaccount/hsregister', model).pipe(
      map((colUser: ColUser) => {
        if (colUser) {
          colUser.colUserType = 'ColLead';
          this.setCurrentColUser(colUser);
          // this.currentColUserSource.next(colUser);
          // this.colUserType = colUser.colUserType;
        }
        // return colUser;
      })
    );
  }

  setCurrentColUser(colUser: ColUser) {
    localStorage.setItem('colUser', JSON.stringify(colUser));
    this.currentColUserSource.next(colUser);
    // this.colUserType = colUser.colUserType;
  }

  logout() {
    localStorage.removeItem('colUser');
    // localStorage.removeItem('loginStatus');
    this.currentColUserSource.next(null);
  }
}
