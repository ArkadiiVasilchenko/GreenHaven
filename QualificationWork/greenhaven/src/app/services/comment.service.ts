import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Comment } from '../models/comment';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  private commentApi = environment.commentApi + '/api/CommentManagement';

  constructor(private http: HttpClient, private router: Router) {}

  GetComments(postId : string): Observable<Array<Comment>> {
    console.log('in comment_service');

    let token: string = '';
    const jsonString = localStorage.getItem('token');

    if (jsonString !== null) {
      const parsedJson = JSON.parse(jsonString);
      token = parsedJson.token;
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      PostId: `${postId}`,
    });

    return this.http.get<Array<Comment>>(this.commentApi + '/GetComments', {headers});
  }
}
