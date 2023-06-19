import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { UserResponse } from '../models/responses/userresponse';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiHost + '/api/Authentication';
  helper: JwtHelperService;

  constructor(private http: HttpClient, private router: Router) {
    this.helper = new JwtHelperService();
  }

  signUp(user: User): Observable<User> {
    console.log('in signUp_service');
    return this.http.post<User>(this.apiUrl + '/Register', user);
  }

  signIn(user: User): Observable<User> {
    console.log('in signIn_service');
    return this.http.post<User>(this.apiUrl + '/Login', user);
  }
}
