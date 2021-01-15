import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { LoginService } from './../../services/login.service';
import { ILinkedInUserData } from './../../models/linkedin-user-data';

@Component({
  selector: "LinkedinLoginResponseComponent",
  templateUrl: "./linkedin-Login-Response.component.html",
  styleUrls: ["./linkedin-Login-Response.component.scss"]
})
export class LinkedinLoginResponseComponent implements OnInit {
  public linkedInUserData: ILinkedInUserData;
  public linkedInToken = "";

  constructor(
    private route: ActivatedRoute,
    private loginService: LoginService) {}

  ngOnInit() {
    this.linkedInToken = this.route.snapshot.queryParams["code"];
    this.loginService.LinkedInAuth(this.linkedInToken).subscribe((linkedInUserData) => {
      this.linkedInUserData = linkedInUserData;
    });
  }
}
