import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  public signupForm!: FormGroup;
  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      email: [''],
      name: [''],
      password: [''],
      passwordConfirm: ['']
    });
  }

  SignUp(): void {
    this.authService.register(this.signupForm.value).subscribe(res => {
      //alert("SignUp successfull: \n" + res);
      alert("SignUp successfull");
      console.log(res);
      this.signupForm.reset();
      this.router.navigate(['login']);
    }, error => {
      //alert("SignUp fail: \n" + JSON.stringify(error));
      alert("SignUp fail");
      console.log(error);
    });
  }

  /*
    signUp(): void {
      console.log(this.signupForm.value);
      this.http.post('https://localhost:44382/api/User/register', this.signupForm.value, { responseType: "text" })
        .subscribe(res => {
          //alert("SignUp successfull: \n" + res);
          alert("SignUp successfull");
          console.log(res);
          this.signupForm.reset();
          this.router.navigate(['login']);
        }, error => {
          //alert("SignUp fail: \n" + JSON.stringify(error));
          alert("SignUp fail");
          console.log(error);
        });
    }*/
}
