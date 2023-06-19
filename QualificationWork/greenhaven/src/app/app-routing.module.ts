
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { NewpostComponent } from './profile/newpost/newpost.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((x) => x.AuthModule),
  },
  {
    path: 'blog',
    loadChildren: () => import('./blog/blog.module').then((x) => x.BlogModule),
  },
  { path: 'profile', component: ProfileComponent },
  { path: 'newpost', component: NewpostComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}