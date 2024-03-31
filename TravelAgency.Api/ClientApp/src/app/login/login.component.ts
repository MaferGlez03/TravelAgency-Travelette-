import { Component } from '@angular/core';
import { SignupComponent } from '../signup/signup.component';
import { RouterOutlet } from '@angular/router';
import {RouterModule} from '@angular/router'

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterOutlet, LoginComponent, SignupComponent, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {

}


