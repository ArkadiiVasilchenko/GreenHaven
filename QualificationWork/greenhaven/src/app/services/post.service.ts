import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../models/post';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private postApi = environment.postApi + '/api/PostManagement';
  helper: JwtHelperService;

  constructor(private http: HttpClient, private router: Router) {
    this.helper = new JwtHelperService();
  }

  GetPosts(): Observable<Array<Post>> {
    console.log('in post_service');

    let token: string = '';
    const jsonString = localStorage.getItem('token');

    if (jsonString !== null) {
      const parsedJson = JSON.parse(jsonString);
      token = parsedJson.token;
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<Array<Post>>(this.postApi + '/GetPosts', {headers});
  }

  GetPostsByUser(): Observable<Array<Post>> {
    console.log('in post_service');

    let token: string = '';
    const jsonString = localStorage.getItem('token');

    if (jsonString !== null) {
      const parsedJson = JSON.parse(jsonString);
      token = parsedJson.token;
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      Token: `${token}`,
    });

    return this.http.get<Array<Post>>(this.postApi + '/GetPostsByUser', {headers});
  }

  CreatePost(post: Post): Observable<Post> {
    console.log('in create_post, post_service');
    let token: string = '';
    const jsonString = localStorage.getItem('token');

    if (jsonString !== null) {
      const parsedJson = JSON.parse(jsonString);
      token = parsedJson.token;
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      Token: `${token}`,
    });

    return this.http.post<Post>(this.postApi + '/CreatePost', post, {
      headers,
    });
  }
}
