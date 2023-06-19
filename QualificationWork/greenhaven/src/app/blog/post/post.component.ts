
import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/models/post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  post!: Post;
  posts: Array<Post> = [];
  constructor(private postService: PostService, private router: Router) {}

  ngOnInit() {
    this.postService.GetPosts().subscribe((result: Array<Post>) => {
      if (result != null) {
        this.posts = result;
        this.post = this.posts[0];
      }
    });
  }

  nextPost() {
    const currentIndex = this.posts.indexOf(this.post);
    const nextIndex = currentIndex + 1;
  
    if (nextIndex < this.posts.length) {
      this.post = this.posts[nextIndex];
    } else {
      this.post = this.posts[0];
    }
  }

  previousPost(): void {
    const currentIndex = this.posts.indexOf(this.post);
    const previousIndex = currentIndex - 1;
  
    if (previousIndex >= 0) {
      this.post = this.posts[previousIndex];
    } else {
      this.post = this.posts[this.posts.length - 1];
    }
  }

  openComments(postId: string){
    this.router.navigate(['/blog/chat'], { queryParams: { postId: `${postId}` }});
  }
  
}
