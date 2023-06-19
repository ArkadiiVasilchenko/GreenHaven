
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from './blog-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PostComponent } from './post/post.component';
import { NgModule } from '@angular/core';
import { CommentComponent } from './comment/comment.component';

@NgModule({
  declarations: [PostComponent, CommentComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, BlogRoutingModule],
})
export class BlogModule {}
