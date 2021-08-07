import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ColMember } from 'src/app/_models/colMember';
import { ColMembersService } from 'src/app/_services/col-members.service';

@Component({
  selector: 'app-colmember-card',
  templateUrl: './colmember-card.component.html',
  styleUrls: ['./colmember-card.component.css'],
})
export class ColmemberCardComponent implements OnInit {
  @Input() colMember: ColMember;

  constructor(
    private colMemberService: ColMembersService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  addLike(colMember: ColMember) {
    this.colMemberService.addLike(colMember.colUsername).subscribe(() => {
      this.toastr.success(
        'You have indicated a possible fit at ' + colMember.collegeNickname
      );
    });
  }
}
