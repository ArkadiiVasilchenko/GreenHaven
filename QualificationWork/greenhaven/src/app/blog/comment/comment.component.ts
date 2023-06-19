import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import { Comment } from 'src/app/models/comment';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
})
export class CommentComponent implements OnInit, OnDestroy {
  comment!: Comment;
  comments: Array<Comment> = [];
  connection!: signalR.HubConnection;
  paramValue: any = '';
  postId: string = '';
  commentForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private commentService: CommentService
  ) {
    this.commentForm = this.formBuilder.group({
      text: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.postId = params['postId'];
    });

    this.commentService
      .GetComments(this.postId)
      .subscribe((result: Array<Comment>) => {
        if (result != null) {
          this.comments = result;
        }
      });

      let token: string = '';
      const jsonString = localStorage.getItem('token');
  
      if (jsonString !== null) {
        const parsedJson = JSON.parse(jsonString);
        token = parsedJson.token;
      }

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7287/comments?postId=' + this.postId, {accessTokenFactory: () => token})
      .withAutomaticReconnect()
      .build();

    this.connection.on('Send', (comment: Comment) => {
      this.comment = comment;
      this.comments.push(comment);
    });

    this.connection.start();
  }

  ngOnDestroy(): void {
    this.connection.stop();
  }

  sendComment(commentText: string) {
    this.commentForm.reset();

    let token: string = '';
    const jsonString = localStorage.getItem('token');

    if (jsonString !== null) {
      const parsedJson = JSON.parse(jsonString);
      token = parsedJson.token;
    }

    this.connection.send('SendMessage', commentText, token, this.postId);
  }
}
