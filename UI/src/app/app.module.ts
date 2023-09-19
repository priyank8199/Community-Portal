import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { RichTextEditorModule } from '@syncfusion/ej2-angular-richtexteditor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from './header/header.component';
import { BodyComponent } from './body/body.component';
import { FooterComponent } from './footer/footer.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ArticlePostsComponent } from './article/article-posts/article-posts.component';
import { ArticleCreateComponent } from './article/article-create/article-create.component';
import { HomeComponent } from './home/home.component';
import { UserService } from './shared/user.service';
import { AuthInterceptor } from './auth/auth.intercepter';
import { ArticleCommentComponent } from './article/article-comment/article-comment.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BodyComponent,
    FooterComponent,
    RegistrationComponent,
    LoginComponent,
    UserProfileComponent,
    ArticlePostsComponent,
    ArticleCreateComponent,
    HomeComponent,
    ArticleCommentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    RichTextEditorModule
  ],
  providers: [UserService,{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi : true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
