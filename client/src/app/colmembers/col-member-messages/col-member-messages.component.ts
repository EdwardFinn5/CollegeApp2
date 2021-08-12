import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/_models/message';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-col-member-messages',
  templateUrl: './col-member-messages.component.html',
  styleUrls: ['./col-member-messages.component.css'],
})
export class ColMemberMessagesComponent implements OnInit {
  @ViewChild('messageForm') messageForm: NgForm;
  @Input() messages: Message[];
  @Input() colUsername: string;
  messageContent: string;
  // loading = false;

  constructor(private messageService: MessageService) {}

  ngOnInit(): void {}

  sendMessage() {
    // this.loading = true;
    this.messageService
      .sendMessage(this.colUsername, this.messageContent)
      .subscribe((message) => {
        this.messages.push(message);
        this.messageForm.reset();
      });
  }
}
