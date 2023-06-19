import { RouterModule, Routes } from '@angular/router';
import { PostComponent } from './post/post.component';
import { NgModule } from '@angular/core';
import { CommentComponent } from './comment/comment.component';

const routes: Routes = [
  {
    path: 'post',
    component: PostComponent,
  },
  {
    path: 'chat',
    component: CommentComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlogRoutingModule {}
