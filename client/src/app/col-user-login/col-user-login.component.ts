import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ColAccountService } from '../_services/col-account.service';

@Component({
  selector: 'app-col-user-login',
  templateUrl: './col-user-login.component.html',
  styleUrls: ['./col-user-login.component.css'],
})
export class ColUserLoginComponent implements OnInit {
  model: any = {};
  loggedIn: boolean = false;

  constructor(
    private router: Router,
    private colAccountService: ColAccountService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.colAccountService.colLogin(this.model).subscribe(
      (response) => {
        console.log(response);
        this.router.navigateByUrl('/colmembers');
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.error);
      }
    );
  }

  logout() {
    this.colAccountService.logout();
  }

  cancel() {
    console.log('cancelled');
    // this.cancelLogin.emit(false);
    this.router.navigateByUrl('/');
  }
}
