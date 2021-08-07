import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ColMember } from '../_models/colMember';
import { ColUser } from '../_models/colUser';
import { ColUserParams } from '../_models/colUserParams';
import { PaginatedResult } from '../_models/pagination';
import { ColAccountService } from './col-account.service';

@Injectable({
  providedIn: 'root',
})
export class ColMembersService {
  baseUrl = environment.apiUrl;
  colMembers: ColMember[] = [];
  colUserType: string;

  constructor(
    private http: HttpClient,
    private colAccountService: ColAccountService
  ) {}

  getColMembers(colUserParams: ColUserParams) {
    this.getCurrentColUserType();
    let params = this.getPaginationHeaders(
      colUserParams.pageNumber,
      colUserParams.pageSize
    );

    if ((this.colUserType = 'College')) {
      params = params.append(
        'minEnrollment',
        colUserParams.minEnrollment.toString()
      );
      params = params.append(
        'maxEnrollment',
        colUserParams.maxEnrollment.toString()
      );
      params = params.append('colUserType', colUserParams.colUserType);
      params = params.append('collegeLocation', colUserParams.collegeLocation);
      params = params.append('orderBy', colUserParams.orderBy);
    }

    if ((this.colUserType = 'ColLead')) {
      params = params.append('colUserType', colUserParams.colUserType);
      params = params.append('classYear', colUserParams.classYear);
      params = params.append('proposedMajor', colUserParams.proposedMajor);
      params = params.append('orderBy', colUserParams.orderBy);
    }

    return this.getPaginatedResults<ColMember[]>(
      this.baseUrl + 'colUsers',
      params
    );
  }

  getColMember(colUsername: string) {
    const colMember = this.colMembers.find(
      (x) => x.colUsername === colUsername
    );
    if (colMember !== undefined) return of(colMember);
    return this.http.get<ColMember>(this.baseUrl + 'colUsers/' + colUsername);
  }

  updateColMember(colMember: ColMember) {
    return this.http.put(this.baseUrl + 'colUsers', colMember).pipe(
      map(() => {
        const index = this.colMembers.indexOf(colMember);
        this.colMembers[index] = colMember;
      })
    );
  }

  setMainPhoto(photoId: number) {
    return this.http.put(
      this.baseUrl + 'colUsers/set-main-photo/' + photoId,
      {}
    );
  }

  deletePhoto(colPhotoId: number) {
    return this.http.delete(
      this.baseUrl + 'colUsers/delete-colPhoto/' + colPhotoId
    );
  }

  private getPaginatedResults<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.http
      .get<T>(url, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') !== null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        })
      );
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();

    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return params;
  }

  getCurrentColUserType() {
    const colUser: ColUser = JSON.parse(localStorage.getItem('colUser'));
    if (colUser) {
      this.colAccountService.setCurrentColUser(colUser);
      this.colUserType = colUser.colUserType;
      console.log(colUser.colUserType);
    }
  }
}
