
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  authForm!: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.authForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    localStorage.clear();
  }

  signUp(user: User) {
    console.log('in method');
    if (!this.authForm.valid) return;
    //Enable loader
    this.loading = true;
    return this.authService.signUp(user).subscribe((users) => {
      this.loading = false;
      //Add user data to local storage
      localStorage.setItem('token', JSON.stringify(users));
      // Redirect user to protected route
      this.router.navigateByUrl('/profile');
    });
  }
}
