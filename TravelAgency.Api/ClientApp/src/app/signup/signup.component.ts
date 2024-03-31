import { Component } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RouterOutlet } from '@angular/router';
import {RouterModule} from '@angular/router'

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [RouterOutlet, LoginComponent, SignupComponent, RouterModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

}
