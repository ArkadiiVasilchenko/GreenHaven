
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit{
  authForm!: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {
    this.authForm = this.formBuilder.group({
      email: [''],
      password: [''],
    });
  }

  ngOnInit(): void {
    localStorage.clear();
  }



  signIn(user: User) {
    console.log('in method');
    if (!this.authForm.valid) return;
    //Enable loader
    this.loading = true;
    return this.authService.signIn(user).subscribe((user) => {
      this.loading = false;
      //Add user data to local storage
      localStorage.setItem('token', JSON.stringify(user));
      // Redirect user to protected route
      this.router.navigateByUrl('/profile');
    });
  }
}
