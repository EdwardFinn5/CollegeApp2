import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ColMember } from '../_models/colMember';

@Injectable({
  providedIn: 'root',
})
export class ColMembersService {
  baseUrl = environment.apiUrl;
  colMembers: ColMember[] = [];

  constructor(private http: HttpClient) {}

  getColMembers() {
    if (this.colMembers.length > 0) return of(this.colMembers);
    return this.http.get<ColMember[]>(this.baseUrl + 'colUsers').pipe(
      map((colMembers) => {
        this.colMembers = colMembers;
        return colMembers;
      })
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
}
