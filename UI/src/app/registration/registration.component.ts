import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  title: 'registration';
  showModal: boolean;
  submitted = false;

  constructor(public service: UserService,private formBuilder: FormBuilder, private _router: Router) { }
  
  ngOnInit(): void {  }
  
  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid

    if(this.submitted)
    {
      this.service.register().subscribe(
        (res : any) => {
          if(res.Succeeded){
            this.service.formModel.reset();
            this._router.navigate(['/login'])
            this.showModal = false;
            console.log("WOW!! You have successfully Registered..Directing to Login");
          } else{
            console.log(res);
            res.Errors.forEach((element: any) => {
              switch(element.Code){
                case 'DuplicateUserName':
                  alert(element.Description);
                  break;
                default:
                  console.log('Error Occured: ' + element.Description);
                  break;
              }
            });
            // console.log(res.Errors);
          }
        },
        err => 
        {
          console.log(err);
        }
      );
    }
  }
  gotologin(){
    this._router.navigate(['/login'])
  }
  close(){
    this._router.navigate(['/'])
  }
}
