import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm!: FormGroup
  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [''],
      password: ['']
    })
  }

  Login(): void {
    this.authService.login(this.loginForm.value).subscribe(res => {
      alert("Login successfull");
      console.log(res);
      //window.location.reload();
      this.router.navigate(['user']);
    }, error => {
      alert("Login fail");
      console.log(error);
    })
  }

  /*
    login(): void {
      this.http.post<any>('https://localhost:44382/api/User/login', this.loginForm.value)
        .subscribe(res => {
          const user = res.find((a: any) => {
            return a.email === this.loginForm.value.email && a.password === this.loginForm.value.password;
          });
          if (user) {
            alert("login successes");
            this.loginForm.reset();
            this.router.navigate(['user']);
          } else {
            alert("user not found");
          }
        }, error => {
          alert("login is fail" + JSON.stringify(error));
        });
    }*/
}
