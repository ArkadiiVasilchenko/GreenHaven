import { Component } from '@angular/core';
import { Post } from '../models/post';
import { PostService } from '../services/post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  post!: Post;
  posts: Array<Post> = [];
  constructor(private postService: PostService, private router: Router) {}

  ngOnInit() {
    this.postService. GetPostsByUser().subscribe((result: Array<Post>) => {
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
