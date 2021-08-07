import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { ColMember } from 'src/app/_models/colMember';
import { ColUser } from 'src/app/_models/colUser';
import { ColUserParams } from 'src/app/_models/colUserParams';
import { Pagination } from 'src/app/_models/pagination';
import { ColAccountService } from 'src/app/_services/col-account.service';
import { ColMembersService } from 'src/app/_services/col-members.service';

@Component({
  selector: 'app-colmember-list',
  templateUrl: './colmember-list.component.html',
  styleUrls: ['./colmember-list.component.css'],
})
export class ColmemberListComponent implements OnInit {
  colMembers: ColMember[];
  pagination: Pagination;
  colUserParams: ColUserParams;
  colUser: ColUser;
  colUserTypeList = [
    { value: 'College', display: 'Colleges' },
    { value: 'ColLead', display: 'HS Students' },
  ];
  collegeLocationList = [
    { value: 'Sioux City, IA', display: 'Sioux City' },
    { value: 'Des Moines, IA', display: 'Des Moines' },
    { value: 'Cedar Rapids, IA', display: 'Cedar Rapids' },
  ];
  classYearList = [
    { value: 'Junior', display: 'Juniors' },
    { value: 'Senior', display: 'Seniors' },
  ];
  proposedMajorList = [
    { value: 'Accounting', display: 'Accounting' },
    { value: 'Finance', display: 'Finance' },
  ];

  constructor(
    private colMemberService: ColMembersService,
    private colAccountService: ColAccountService
  ) {
    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => {
        this.colUser = colUser;
        this.colUserParams = new ColUserParams(colUser);
      });
  }

  ngOnInit(): void {
    this.loadColMembers();
  }

  loadColMembers() {
    this.colMemberService
      .getColMembers(this.colUserParams)
      .subscribe((response) => {
        this.colMembers = response.result;
        this.pagination = response.pagination;
      });
  }

  resetFilters() {
    this.colUserParams = new ColUserParams(this.colUser);
    this.loadColMembers();
  }

  pageChanged(event: any) {
    this.colUserParams.pageNumber = event.page;
    this.loadColMembers();
  }
}
