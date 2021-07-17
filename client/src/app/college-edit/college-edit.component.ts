import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { ColMember } from '../_models/colMember';
import { ColUser } from '../_models/colUser';
import { ColAccountService } from '../_services/col-account.service';
import { ColMembersService } from '../_services/col-members.service';

@Component({
  selector: 'app-college-edit',
  templateUrl: './college-edit.component.html',
  styleUrls: ['./college-edit.component.css'],
})
export class CollegeEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  colMember: ColMember;
  colUser: ColUser;
  @HostListener('window:beforeunload', ['$event']) unloadNotification(
    $event: any
  ) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  // galleryOptions: NgxGalleryOptions[];
  // galleryImages: NgxGalleryImage[];

  constructor(
    private colAccountService: ColAccountService,
    private colMemberService: ColMembersService,
    private toastr: ToastrService
  ) {
    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => (this.colUser = colUser));
  }

  ngOnInit(): void {
    this.loadColMember();
  }

  loadColMember() {
    this.colMemberService
      .getColMember(this.colUser.colUserName)
      .subscribe((colMember) => {
        this.colMember = colMember;
      });
  }

  updateColMember() {
    this.colMemberService.updateColMember(this.colMember).subscribe(() => {
      this.toastr.success('Profile updated successfully');
      this.editForm.reset(this.colMember);
    });
  }
}
