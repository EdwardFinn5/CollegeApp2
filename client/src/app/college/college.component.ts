import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-college',
  templateUrl: './college.component.html',
  styleUrls: ['./college.component.css'],
})
export class CollegeComponent implements OnInit {
  hsRegisterMode = false;
  model: any = {};
  loggedIn: boolean;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  registerToggle() {
    this.hsRegisterMode = !this.hsRegisterMode;
  }

  onLoginBtn() {
    this.router.navigate(['/coluserlogin']);
  }

  onRegisterBtn() {
    this.router.navigate(['/hsregister']);
  }

  cancelHsRegisterMode(event: boolean) {
    this.hsRegisterMode = event;
  }

  cancel() {
    console.log('cancelled');
    this.router.navigateByUrl('/');
  }
}
