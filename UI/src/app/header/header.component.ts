import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  loggedIn : boolean = false;
  title = 'user-profile';
  userDetails : any;

  constructor(private _router : Router,private service:UserService) { }
  
  ngOnInit(): void {
    if(localStorage.getItem('token')!= null){
      this.loggedIn = true;
      this.service.getUserProfile().subscribe(
        (res) => {
          this.userDetails = res;
          console.log(this.userDetails);
          
        }, (err) => {
          console.log(err);
        }
      );
    }    
  }
  login(){
    if(localStorage.getItem('token')==null)
    {
      this.loggedIn = true;
      this._router.navigate(['/login']);
    }
  }
  logout(){
    alert('logged out');
    localStorage.removeItem('token');
    this._router.navigate(['/']);
    this.loggedIn = false;
  }
  createarticle(){
    this._router.navigate(['article-create'])
  }
}
