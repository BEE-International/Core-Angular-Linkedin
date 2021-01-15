import { Component } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from './../../../environments/environment';

const endpoint = environment.endpoint;
const clientId = environment.clientId;
const redirectUrl = environment.redirectUrl;
const state = environment.state;

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: "LoginComponent",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent {

  constructor(private http: HttpClient) {}

  login() {
    window.location.href = `https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=${
      clientId
    }&scope=r_liteprofile&redirect_uri=${redirectUrl}&state=${state}`;
  }
}
