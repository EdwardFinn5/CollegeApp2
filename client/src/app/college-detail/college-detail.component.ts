import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { ColMember } from '../_models/colMember';
import { Message } from '../_models/message';
import { ColMembersService } from '../_services/col-members.service';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-college-detail',
  templateUrl: './college-detail.component.html',
  styleUrls: ['./college-detail.component.css'],
})
export class CollegeDetailComponent implements OnInit {
  @ViewChild('colMemberTabs', { static: true }) colMemberTabs: TabsetComponent;
  colMember: ColMember;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  activeTab: TabDirective;
  messages: Message[] = [];

  constructor(
    private colMemberService: ColMembersService,
    private route: ActivatedRoute,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.colMember = data.colMember;
    });

    this.route.queryParams.subscribe((params) => {
      params.tab ? this.selectTab(params.tab) : this.selectTab(0);
    });

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
    this.galleryImages = this.getCollegeImages();
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

  loadMessages() {
    this.messageService
      .getMessageThread(this.colMember.colUsername)
      .subscribe((messages) => {
        this.messages = messages;
      });
  }

  selectTab(tabId: number) {
    this.colMemberTabs.tabs[tabId].active = true;
  }

  onTabActivated(data: TabDirective) {
    this.activeTab = data;
    if (this.activeTab.heading === 'Messages' && this.messages.length === 0) {
      this.loadMessages();
    }
  }
}
