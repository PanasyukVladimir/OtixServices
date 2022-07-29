import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";
import { Injectable } from '@angular/core';
import { HttpHeaders } from "@angular/common/http";
import { HttpParams } from "@angular/common/http";



class UserInfo {
    name: string;
    email: string;
    emailConfirmed: string;
    phoneNumber: string;
    phoneNumberConfirmed: string;

    constructor(Name: string, Email: string, EmailConfirmed: string, PhoneNumber: string, PhoneNumberConfirmed: string) {
        this.name = Name;
        this.email = Email;
        this.emailConfirmed = EmailConfirmed;
        this.phoneNumber = PhoneNumber;
        this.phoneNumberConfirmed = PhoneNumberConfirmed;
    };
}

@Injectable({
    providedIn: 'root',
})

export class AuthService {

    authUrl = "https://localhost:44382/api/User/";

    constructor(private http: HttpClient) { }

    register(model: any) {
        return this.http.post(this.authUrl + 'register', model, { responseType: "text" });
    }

    login(model: any) {
        return this.http.post(this.authUrl + 'login', model, { responseType: "text" }).pipe(
            map((response: any) => {
                const userId = response;
                if (userId != null) {
                    localStorage.setItem('Id', userId);
                }
            })
        );
    }

    edit(model: any) {
        return this.http.post(this.authUrl + 'edit', model, { responseType: "text" });
    }

    delete(model: any) {
        return this.http.post(this.authUrl + 'delete', model, { responseType: "text" });
        /*.pipe(
            map((response: any) => {
                console.log(response);
                const ConfirmDelete = response;
                if (ConfirmDelete == true) {
                    localStorage.clear();
                }
            })
        );*/
    }

    logout(model: any) {
        return this.http.post(this.authUrl + 'logout', model, { responseType: "text" });
        /*.pipe(
            map((response: any) => {
                console.log(response);
                const ConfirmLogout = response;
                if (ConfirmLogout == true) {
                    localStorage.clear();
                }
            })*/
    }

    checkAuth(): boolean {
        let userID = localStorage.getItem('Id');
        console.log(userID);
        if (userID != null) {
            return true;
        }
        else {
            return false;
        }

    }


    getUserInfo(userId: any) {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        //headers.append('id', userId);
        let params = new HttpParams().set("id", userId);

        return this.http.get<UserInfo>(this.authUrl + 'get', { headers: headers, params: params });
    }
}
