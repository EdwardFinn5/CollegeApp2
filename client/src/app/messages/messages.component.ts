import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { ColUser } from '../_models/colUser';
import { Message } from '../_models/message';
import { Pagination } from '../_models/pagination';
import { ColAccountService } from '../_services/col-account.service';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css'],
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  pagination: Pagination;
  container = 'Unread';
  pageNumber = 1;
  pageSize = 2;
  colUser: ColUser;
  loading = false;

  constructor(
    private messageService: MessageService,
    private colAccountService: ColAccountService // private confirmService: ConfirmService
  ) {
    this.colAccountService.currentColUser$
      .pipe(take(1))
      .subscribe((colUser) => (this.colUser = colUser));
  }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.loading = true;
    this.messageService
      .getMessages(this.pageNumber, this.pageSize, this.container)
      .subscribe((response) => {
        this.messages = response.result;
        this.pagination = response.pagination;
        this.loading = false;
      });
  }

  deleteMessage(id: number) {
    // this.confirmService
    //   .confirm('Confirm delete message', 'This cannot be undone')
    //   .subscribe((result) => {
    //     if (result) {
    this.messageService.deleteMessage(id).subscribe(() => {
      this.messages.splice(
        this.messages.findIndex((m) => m.id === id),
        1
      );
    });
    //   }
    // });
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadMessages();
  }
}
