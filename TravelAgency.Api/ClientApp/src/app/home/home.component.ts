import { Component } from '@angular/core';
import { HomePaqueteComponent } from './home-paquete/home-paquete.component';
import { HomeOfertaComponent } from './home-oferta/home-oferta.component';
import { HomeExcursionComponent } from './home-excursion/home-excursion.component';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [HomePaqueteComponent, HomeOfertaComponent, HomeExcursionComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})

export class HomeComponent {

}
