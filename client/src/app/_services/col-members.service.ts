// import { HttpClient } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { map } from 'rxjs/operators';
// import { environment } from 'src/environments/environment';
// import { ColMember } from '../_models/colMember';

// @Injectable({
//   providedIn: 'root',
// })
// export class ColMembersService {
//   baseUrl = environment.apiUrl;

//   constructor(private http: HttpClient) {}

//   getColMembers() {
//     return this.http.get<ColMember[]>(this.baseUrl + 'colusers');
//   }

//   getColMember(colusername: string) {
//     return this.http.get<ColMember>(this.baseUrl + 'colusers/' + colusername);
//   }

//   updateColMember(colMember: ColMember) {
//     return this.http.put(this.baseUrl + 'colUsers', colMember);

//     // .pipe(
//     //   map(() => {
//     //     const index = this.colMembers.indexOf(colMember);
//     //     this.colMembers[index] = member;
//     //   })
//     // );
//   }
//   setMainPhoto(photoId: number) {
//     return this.http.put(
//       this.baseUrl + 'colUsers/set-main-photo/' + photoId,
//       {}
//     );
//   }

//   deletePhoto(colPhotoId: number) {
//     return this.http.delete(
//       this.baseUrl + 'colUsers/delete-colPhoto/' + colPhotoId
//     );
//   }
// }
