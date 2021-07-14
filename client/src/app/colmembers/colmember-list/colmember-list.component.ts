import { Component, OnInit } from '@angular/core';
import { ColMember } from 'src/app/_models/colMember';
import { ColMembersService } from 'src/app/_services/col-members.service';

@Component({
  selector: 'app-colmember-list',
  templateUrl: './colmember-list.component.html',
  styleUrls: ['./colmember-list.component.css'],
})
export class ColmemberListComponent implements OnInit {
  colMembers: ColMember[];

  constructor(private colMemberService: ColMembersService) {}

  ngOnInit(): void {
    this.loadColMembers();
  }

  loadColMembers() {
    this.colMemberService.getColMembers().subscribe((colMembers) => {
      this.colMembers = colMembers;
    });
  }
}
