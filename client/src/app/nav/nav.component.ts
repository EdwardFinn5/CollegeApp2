import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ColUserLoginComponent } from '../col-user-login/col-user-login.component';
import { ColUser } from '../_models/colUser';
import { ColAccountService } from '../_services/col-account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(
    public colAccountService: ColAccountService,
    private route: Router
  ) {}

  ngOnInit(): void {}

  login() {
    this.colAccountService.colLogin(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  logout() {
    this.colAccountService.logout();
    this.route.navigateByUrl('/');
  }
}
