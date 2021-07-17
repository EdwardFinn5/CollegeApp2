import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ColMember } from 'src/app/_models/colMember';
import { ColMembersService } from 'src/app/_services/col-members.service';

@Component({
  selector: 'app-colmember-list',
  templateUrl: './colmember-list.component.html',
  styleUrls: ['./colmember-list.component.css'],
})
export class ColmemberListComponent implements OnInit {
  colMembers$: Observable<ColMember[]>;

  constructor(private colMemberService: ColMembersService) {}

  ngOnInit(): void {
    this.colMembers$ = this.colMemberService.getColMembers();
  }
}
