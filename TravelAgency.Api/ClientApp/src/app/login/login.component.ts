import { LoginService } from '../Services/login.service';
import { Component } from '@angular/core';
import { SignupComponent } from '../register/signup.component';
import { Router, RouterOutlet } from '@angular/router';
import { RouterModule } from '@angular/router'
import { IdService } from '../Services/MovimientoDatos/id.service';

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [RouterOutlet, LoginComponent, SignupComponent, RouterModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})

export class LoginComponent {
    constructor(
        private router: Router,
        private loginService: LoginService,
        private idService: IdService) { }

    loginPost() {
        let post = {
            userName: (document.getElementById('userName') as HTMLInputElement).value,
            password: (document.getElementById('password') as HTMLInputElement).value
        }

        this.loginService.loginPost(post).subscribe({
            next: (response) => {
                this.idService.changeId(post.userName, response.toString())
                this.router.navigate(['../home']);
            }
        })
    }

    dontSeePath = '../../assets/eye-password-hide-svgrepo-com.svg'
    seePath = '../../assets/eye-password-show-svgrepo-com.svg'
    imgPath = this.seePath

    showPassword: boolean = false
    see() {

        var passwordInput = document.getElementById("password") as HTMLInputElement;
        if (passwordInput) {
            this.showPassword = !this.showPassword
            if (passwordInput.type === "password") {
                this.imgPath = this.dontSeePath
            } else {
                this.imgPath = this.seePath
            }
        }
    }
}


