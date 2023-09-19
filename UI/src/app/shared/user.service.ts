import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { ConfirmedValidator } from '../custom-validators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb:FormBuilder,private http:HttpClient) { }

  readonly APIURL = "http://localhost:65241/api";
  formModel = this.fb.group({
    FirstName: ['',[Validators.required,  Validators.minLength(2), Validators.pattern('^[_A-z]*((-|\s)*[_A-z])*$')]],

    LastName: ['',[Validators.required,  Validators.minLength(2), Validators.pattern('^[_A-z]*((-|\s)*[_A-z])*$')]],

    UserName: ['',[Validators.required,  Validators.minLength(2), Validators.pattern('^[_A-z0-9]*((-|\s)*[_A-z0-9])*$')]],

    Email: ['', [Validators.required, Validators.email]],

    Password: ['', [Validators.required, Validators.minLength(8),Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]],

    confirmpassword: ['', [Validators.required, Validators.minLength(8),Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]]
    },{
      validator: ConfirmedValidator('Password', 'confirmpassword')
    }
  );
  get f() { return this.formModel.controls; }

  register(){
    var body = {
      UserName : this.formModel.value.UserName,
      Email : this.formModel.value.Email,
      Password : this.formModel.value.Password,
      FirstName : this.formModel.value.FirstName,
      LastName : this.formModel.value.LastName,
    };
    return this.http.post(this.APIURL + "/ApplicationUser/Register",body);
  }

  login(formData: any){
    return this.http.post(this.APIURL + "/ApplicationUser/Login",formData);
  }

  getUserProfile(){
    return this.http.get(this.APIURL + '/UserProfile');
  }

  getCategories(){
    return this.http.get(this.APIURL + '/Category');
  }

  getAllArticles(){
    return this.http.get(this.APIURL + '/Post');
  }

  postArticle(article:any){
    return this.http.post(this.APIURL + '/Post',article);
  }
}
