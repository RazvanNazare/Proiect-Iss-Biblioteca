import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UserLoginModel } from 'src/app/models/userLogin.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  formValue: FormGroup;
  subscriptions: Subscription[] = [];
  isLoggedIn: boolean = false;
  currentlyLoggedUser: UserLoginModel;

  users: UserLoginModel[] = [
    { email: "William", password: "123456" },
    { email: "Nelson", password: "4321" }
  ];

  constructor(private formBuilder: FormBuilder) { }


  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      cnp: new FormControl('', [Validators.required]),
      adress: new FormControl('', [Validators.required]),
      mobile: new FormControl('', [Validators.required]),
    })
  }

  get formGroupControls() {
    return this.formValue.controls;
  }

  onLogin(){
    this.formValue.reset();
  }

  onSignIn(){
    this.formValue.reset();
  }

  onSignOut(){
    this.isLoggedIn = false;
    this.currentlyLoggedUser.email = "";
  }

  onLoginVerification() {
    let loginData = this.formValue.getRawValue();

    this.users.forEach(user => {
      if (user.email == loginData.email && user.password == loginData.password) {
        this.isLoggedIn = true;
        let element: HTMLElement = document.getElementById('cancelLogin') as HTMLElement;
        element.click();
        this.currentlyLoggedUser.email = user.email;
      }
    });
  }

  onSignInVerification() {
    let signInUser = this.formValue.getRawValue();
    this.users.push(signInUser);
    let element: HTMLElement = document.getElementById('cancelSignIn') as HTMLElement;
    element.click();
  }

  ngOnDestroy() {
    if (this.subscriptions.length == 0) return;
    for (let sub of this.subscriptions) {
      sub.unsubscribe();
    }
  }

}
