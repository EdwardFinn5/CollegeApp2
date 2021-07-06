import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

// import { ToastrService } from 'ngx-toastr';

import { ColAccountService } from '../_services/col-account.service';

@Component({
  selector: 'app-college-register',
  templateUrl: './college-register.component.html',
  styleUrls: ['./college-register.component.css'],
})
export class CollegeRegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelCollegeRegister = new EventEmitter();

  constructor(
    private colAccountService: ColAccountService,
    // private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  collegeRegister() {
    this.colAccountService.collegeRegister(this.model).subscribe(
      (response) => {
        console.log(response);
        this.cancel();
        this.router.navigateByUrl('/colmembers');
      },
      (error) => {
        console.log(error);
        // this.toastr.error(error.error);
      }
    );
  }

  cancel() {
    console.log('cancelled');
    this.cancelCollegeRegister.emit(false);
    this.router.navigateByUrl('/');
  }
}
