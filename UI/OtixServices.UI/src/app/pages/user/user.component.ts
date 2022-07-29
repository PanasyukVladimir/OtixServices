import { Component, OnInit } from "@angular/core";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-user",
  templateUrl: "user.component.html"
})
export class UserComponent implements OnInit {

  user = { Name: '', Email: '', EmailConfirmed: '', PhoneNumber: '', PhoneNumberConfirmed: '', birthday: '' }

  imgUrl: string = 'https://i.redd.it/taai6zguhds61.png'

  public isAuth: boolean = this.authService.checkAuth();
  userId: any = localStorage.getItem('Id');



  constructor(private authService: AuthService) { }

  ngOnInit() {

    if (this.isAuth) {
      //console.log(typeof (this.userId));
      this.authService.getUserInfo(this.userId).subscribe(data => {
        console.log(data);
        this.user.Name = data.name;
        this.user.Email = data.email;
        this.user.EmailConfirmed = data.emailConfirmed;
        this.user.PhoneNumber = data.phoneNumber;
        this.user.PhoneNumberConfirmed = data.phoneNumberConfirmed;
        console.log(this.user);
      }, error => {
        console.log(error);
      })
    }
  }

  //birthdayUser: string = new Date().toDateString();
  birthdayUser: any = localStorage.getItem('birthdayUser');
  newUserName: any = localStorage.getItem('UserName');

  SetBirthday(event: any) {
    console.log(event.target.value);
    localStorage.setItem('birthdayUser', event.target.value);
  }

  SetNewName(event: any) {
    console.log(event.target.value);
    localStorage.setItem('UserName', event.target.value);
  }
  /*
    ChangeImg() {
      this.imgUrl = 'https://i.imgflip.com/57zddg.jpg'
    }*/

  DeleteUser() {
    this.authService.delete({ id: this.userId, name: this.newUserName }).subscribe(res => {
      alert("deleted account successfull");
      console.log(res);
      if (res == "true") {
        localStorage.clear();
        this.isAuth = true;
      }
    }, error => {
      alert("deleted account fail");
      console.log(error);
    });;
  }

  ///TODO
  EditUser() {
    this.authService.edit({ id: this.userId, name: this.newUserName }).subscribe(res => {
      alert("Change UserName successfull");
      console.log(res);
    }, error => {
      alert("Change UserName fail");
      console.log(error);
    });
  }
}
