import { Component, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'
import { HeaderComponent } from './header/header.component'
import { FooterComponent } from './footer/footer.component'
import { HomeComponent } from './home/home.component';
import { HotelOffersComponent } from './hotel-offers/hotel-offers.component';
import { HeaderInComponent } from './header/header-in/header-in.component';
import { HotelOfferBookingComponent } from './hotel-offers/hotel-offer-booking/hotel-offer-booking.component';
import { CommonModule } from '@angular/common';
import { IdService } from './Services/MovimientoDatos/id.service';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [
        CommonModule,
        RouterModule,
        HeaderComponent,
        HeaderInComponent,
        FooterComponent,
        HomeComponent,
        HotelOffersComponent,
        HotelOfferBookingComponent,
    ]
})
export class AppComponent {
    title = 'Travelette'

    postData = {
        name: '',
        address: '',
        fax: '',
        electronicAddress: ''
    }

    isRegistered = false;
    isNotRegistered = true;

    constructor(private IdService: IdService) {
        this.IdService.isRegistered.subscribe(isRegistered => {
            this.isRegistered = isRegistered;
        })
        this.isNotRegistered = false;
    }
}