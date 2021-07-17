import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ColUser } from './_models/colUser';
import { ColAccountService } from './_services/col-account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'College Connect';
  colUsers: any;
  colUserType = 'ColLead';

  constructor(private colAccountService: ColAccountService) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const colUser: ColUser = JSON.parse(localStorage.getItem('colUser'));
    if (colUser) this.colAccountService.setCurrentColUser(colUser);
    this.colUserType = colUser.colUserType;
  }
}
