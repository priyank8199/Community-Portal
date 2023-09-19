import { ArticleCreateComponent } from './article/article-create/article-create.component';
import { HeaderComponent } from './header/header.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { ArticlePostsComponent } from './article/article-posts/article-posts.component';


const routes: Routes = [
  {path:'home', component: HomeComponent},
  {path: 'header', component: HeaderComponent},
  {path:'', redirectTo: '/home', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'app', component: AppComponent},
  {path: 'user-profile', component: UserProfileComponent},
  {path: 'article-create', component:ArticleCreateComponent, canActivate: [AuthGuard]},
  {path: 'article-posts', component:ArticlePostsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
