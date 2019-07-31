import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AuthenticationService } from '../core/services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-authenticate',
  templateUrl: './authenticate.component.html',
  styleUrls: ['./authenticate.component.css']
})
export class AuthenticateComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  isNewUser: boolean;
  buttonText: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/play']);
    }
  }

  ngOnInit() {
    this.buildSignInForm();

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/play';
  }

  buildSignInForm() {
    this.loginForm = this.formBuilder.group({
      username: ['burnoutdev', Validators.required],
      password: ['burnindev', Validators.required]
    });

    this.buttonText =  'Sign In';
    this.isNewUser = false;
  }

   buildRegisterForm() {
    this.loginForm = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      username: ['burnoutdev', Validators.required],
      password: ['burnindev', Validators.required]
    });

    this.buttonText =  'Register';
    this.isNewUser = true;
  }

  get f() { return this.loginForm.controls; }

  submit() {
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;

    if (this.isNewUser) {
      this.authenticationService.register(this.f.username.value, this.f.password.value, this.f.firstname.value, this.f.lastname.value)
      .pipe(first())
      .subscribe(
        data => {
          console.log(data);
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
    } else {
    this.authenticationService.login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
      }
  }
}
