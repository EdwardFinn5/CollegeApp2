import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ColAccountService } from '../_services/col-account.service';

@Component({
  selector: 'app-college-register',
  templateUrl: './college-register.component.html',
  styleUrls: ['./college-register.component.css'],
})
export class CollegeRegisterComponent implements OnInit {
  @Output() cancelCollegeRegister = new EventEmitter();
  registerForm: FormGroup;
  validationErrors: string[] = [];

  constructor(
    private colAccountService: ColAccountService,
    private toastr: ToastrService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      colUsername: ['', Validators.required],
      firstName: ['', Validators.required],
      collegeName: ['', Validators.required],
      collegeLocation: ['', Validators.required],
      collegeEnrollment: ['', Validators.required],
      password: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(8)],
      ],
      confirmPassword: [
        '',
        [Validators.required, this.matchValues('password')],
      ],
    });
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  collegeRegister() {
    this.colAccountService.collegeRegister(this.registerForm.value).subscribe(
      (response) => {
        this.cancel();
        this.router.navigateByUrl('/colmembers');
      },
      (error) => {
        console.log(error);
        this.validationErrors = error;
      }
    );
  }

  cancel() {
    console.log('cancelled');
    this.cancelCollegeRegister.emit(false);
    this.router.navigateByUrl('/');
  }
}
