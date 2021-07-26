import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { ColMember } from 'src/app/_models/colMember';
import { ColPhoto } from 'src/app/_models/colPhoto';
import { ColUser } from 'src/app/_models/colUser';
import { ColAccountService } from 'src/app/_services/col-account.service';
import { ColMembersService } from 'src/app/_services/col-members.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent implements OnInit {
  @Input() colMember: ColMember;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  colUser: ColUser;

  constructor(
    private colAccountService: ColAccountService,
    private colMemberService: ColMembersService
  ) {
    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => (this.colUser = colUser));
  }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(event: any) {
    this.hasBaseDropZoneOver = event;
  }

  setMainColPhoto(colPhoto: ColPhoto) {
    this.colMemberService.setMainPhoto(colPhoto.colPhotoId).subscribe(() => {
      this.colUser.colUrl = colPhoto.colUrl;
      this.colAccountService.setCurrentColUser(this.colUser);
      this.colMember.colUrl = colPhoto.colUrl;
      this.colMember.colPhotos.forEach((p) => {
        if (p.isMainCol) {
          p.isMainCol = false;
        }
        if (p.colPhotoId === colPhoto.colPhotoId) {
          p.isMainCol = true;
        }
      });
    });
  }

  setMainHsPhoto(colPhoto: ColPhoto) {
    this.colMemberService.setMainPhoto(colPhoto.colPhotoId).subscribe(() => {
      this.colUser.hsStudentUrl = colPhoto.hsStudentUrl;
      this.colAccountService.setCurrentColUser(this.colUser);
      this.colMember.hsStudentUrl = colPhoto.hsStudentUrl;
      this.colMember.colPhotos.forEach((p) => {
        if (p.isMainHs) {
          p.isMainHs = false;
        }
        if (p.colPhotoId === colPhoto.colPhotoId) {
          p.isMainHs = true;
        }
      });
    });
  }

  deletePhoto(photoId: number) {
    this.colMemberService.deletePhoto(photoId).subscribe(() => {
      this.colMember.colPhotos = this.colMember.colPhotos.filter(
        (x) => x.colPhotoId !== photoId
      );
    });
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'colUsers/add-photo',
      authToken: 'Bearer ' + this.colUser.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const colPhoto: ColPhoto = JSON.parse(response);
        this.colMember.colPhotos.push(colPhoto);
        if (colPhoto.isMainHs) {
          this.colUser.hsStudentUrl = colPhoto.hsStudentUrl;
          this.colMember.hsStudentUrl = colPhoto.hsStudentUrl;
          this.colAccountService.setCurrentColUser(this.colUser);
        }
        if (colPhoto.isMainCol) {
          this.colUser.colUrl = colPhoto.colUrl;
          this.colMember.colUrl = colPhoto.colUrl;
          this.colAccountService.setCurrentColUser(this.colUser);
        }
      }
    };
  }
}
