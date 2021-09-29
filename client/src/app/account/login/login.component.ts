import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.returnUrl =
      this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginForm();
  }
  createLoginForm() {
    this.loginForm = this.fb.group({
      email: [
        'bob@test.com',
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
        ],
      ],
      password: ['Pa$$w0rd', Validators.required],
    });
  }

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe(
      (x) => {
        this.accountService.currentUser$.subscribe((t) => {
          console.log(this.returnUrl);
          this.router.navigateByUrl(this.returnUrl);
        });
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
