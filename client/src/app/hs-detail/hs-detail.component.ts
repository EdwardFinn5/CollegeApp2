import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';
import { ColMember } from '../_models/colMember';
import { ColMembersService } from '../_services/col-members.service';

@Component({
  selector: 'app-hs-detail',
  templateUrl: './hs-detail.component.html',
  styleUrls: ['./hs-detail.component.css'],
})
export class HsDetailComponent implements OnInit {
  colMember: ColMember;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private colMemberService: ColMembersService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadColMember();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
      },
    ];
  }

  getHsImages(): NgxGalleryImage[] {
    const hsStudentUrls = [];
    for (const colPhoto of this.colMember.colPhotos) {
      hsStudentUrls.push({
        small: colPhoto?.hsStudentUrl,
        medium: colPhoto?.hsStudentUrl,
        big: colPhoto?.hsStudentUrl,
      });
    }
    return hsStudentUrls;
  }

  loadColMember() {
    this.colMemberService
      .getColMember(this.route.snapshot.paramMap.get('colusername'))
      .subscribe((colMember) => {
        this.colMember = colMember;
        console.log(colMember.colUsername);
        this.galleryImages = this.getHsImages();
      });
  }
}
