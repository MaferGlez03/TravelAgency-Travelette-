import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import {RouterModule} from '@angular/router'
import {AdminComponent} from './admin/admin.component'
import {HomePaqueteComponent} from './home-paquete/home-paquete.component'
import {HomeOfertaComponent} from './home-oferta/home-oferta.component'
import {HomeExcursionComponent} from './home-excursion/home-excursion.component'
import {HeaderComponent} from './header/header.component'
import {FooterComponent} from './footer/footer.component'
import { RegisterService } from './Services/register.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, 
            LoginComponent, 
            SignupComponent, 
            RouterModule, 
            AdminComponent, 
            HomePaqueteComponent, 
            HomeOfertaComponent, 
            HomeExcursionComponent, 
            HeaderComponent, 
            FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  register = inject(RegisterService)
  
  ngOnInit(): void {
    this.register.getRegister().subscribe((data) => (data));
  }
  title = 'travelette';

}


