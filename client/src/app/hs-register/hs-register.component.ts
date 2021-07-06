import { HttpClient } from '@angular/common/http';
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
import { ColUser } from '../_models/colUser';
// import { ToastrService } from 'ngx-toastr';
import { ColAccountService } from '../_services/col-account.service';

@Component({
  selector: 'app-hs-register',
  templateUrl: './hs-register.component.html',
  styleUrls: ['./hs-register.component.css'],
})
export class HsRegisterComponent implements OnInit {
  @Output() cancelHsRegister = new EventEmitter();
  registerForm: FormGroup;
  colUserType = 'ColLead';
  validationErrors: string[] = [];
  model: any = {};

  constructor(
    private colAccountService: ColAccountService,
    private http: HttpClient,
    // private toastr: ToastrService,
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
      classYear: ['Senior', Validators.required],
      hsName: ['', Validators.required],
      hsLocation: ['', Validators.required],
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

  hsRegister() {
    this.colAccountService.hsRegister(this.model).subscribe(
      (response) => {
        console.log(response);
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
    this.cancelHsRegister.emit(false);
    this.router.navigateByUrl('/');
  }
}
