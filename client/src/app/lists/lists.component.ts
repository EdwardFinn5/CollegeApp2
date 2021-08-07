import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { ColMember } from '../_models/colMember';
import { ColUser } from '../_models/colUser';
import { Pagination } from '../_models/pagination';
import { ColAccountService } from '../_services/col-account.service';
import { ColMembersService } from '../_services/col-members.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css'],
})
export class ListsComponent implements OnInit {
  colMembers: Partial<ColMember[]>;
  predicate = 'liked';
  colUser: ColUser;
  pageNumber = 1;
  pageSize = 2;
  pagination: Pagination;

  constructor(
    private colMemberService: ColMembersService,
    private colAccountService: ColAccountService
  ) {
    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => (this.colUser = colUser));
  }

  ngOnInit(): void {
    //   console.log(this.user.appUserType);
    //   console.log(this.user.username);
    this.loadLikes();
  }

  loadLikes() {
    this.colMemberService
      .getLikes(this.predicate, this.pageNumber, this.pageSize)
      .subscribe((response) => {
        this.colMembers = response.result;
        this.pagination = response.pagination;
      });
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadLikes();
  }
}
