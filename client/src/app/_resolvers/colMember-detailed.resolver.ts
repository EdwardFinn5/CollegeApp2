import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ColMember } from '../_models/colMember';
import { ColMembersService } from '../_services/col-members.service';

@Injectable({
  providedIn: 'root',
})
export class ColMemberDetailedResolver implements Resolve<ColMember> {
  constructor(private colMemberService: ColMembersService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<ColMember> {
    return this.colMemberService.getColMember(
      route.paramMap.get('colusername')
    );
  }
}
