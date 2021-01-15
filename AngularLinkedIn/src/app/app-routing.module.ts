import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent  } from './components/login/login.component';
import { LinkedinLoginResponseComponent } from './components/linkedin-login-response/linkedin-login-response.component';

const routes: Routes = [
  { path: "", redirectTo: "/login", pathMatch: "full" },
  { path: 'login', component: LoginComponent},
  { path: 'linkedinLoginResponse', component: LinkedinLoginResponseComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
