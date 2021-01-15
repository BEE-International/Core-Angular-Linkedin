import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { ILinkedInUserData } from './../models/linkedin-user-data';

const endpoint = environment.endpoint;
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({ providedIn: 'root' })
export class LoginService {
    constructor(private http: HttpClient) { }

    public LinkedInAuth(code: string){
      return this.http.get<ILinkedInUserData>(endpoint + 'Login/LinkedInAuth?code=' + code, httpOptions);
  }
}
