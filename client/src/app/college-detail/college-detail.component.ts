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
  selector: 'app-college-detail',
  templateUrl: './college-detail.component.html',
  styleUrls: ['./college-detail.component.css'],
})
export class CollegeDetailComponent implements OnInit {
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

  getCollegeImages(): NgxGalleryImage[] {
    const colUrls = [];
    for (const colPhoto of this.colMember.colPhotos) {
      colUrls.push({
        small: colPhoto?.colUrl,
        medium: colPhoto?.colUrl,
        big: colPhoto?.colUrl,
      });
    }
    return colUrls;
  }

  loadColMember() {
    this.colMemberService
      .getColMember(this.route.snapshot.paramMap.get('colusername'))
      .subscribe((colMember) => {
        this.colMember = colMember;
        console.log(colMember.colUsername);
        this.galleryImages = this.getCollegeImages();
      });
  }
}
