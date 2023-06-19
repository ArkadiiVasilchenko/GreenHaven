import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Post } from 'src/app/models/post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-newpost',
  templateUrl: './newpost.component.html',
  styleUrls: ['./newpost.component.scss'],
})
export class NewpostComponent {
  postForm!: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private postService: PostService,
    private router: Router
  ) {
    this.postForm = this.formBuilder.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
    });
  }

  createPost(post: Post) {
    console.log('in createPost in component');
    if (!this.postForm.valid) return;
    this.loading = true;

    return this.postService.CreatePost(post).subscribe(() => {
      this.loading = false;
      this.router.navigateByUrl('/profile');
    });
  }
}
