import { HotelOffersService } from '../Services/hotel-offers.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { HotelService } from '../Services/hotel.service';

@Component({
    selector: 'app-hotel-staff',
    standalone: true,
    imports: [RouterModule, CommonModule],
    templateUrl: './hotel-staff.component.html',
    styleUrl: './hotel-staff.component.css'
})
export class HotelStaffComponent implements OnInit {

    constructor(private hotelOffersService: HotelOffersService,
        private hotelService: HotelService,
        private router: Router) { }
    NombreHotel = "Selecciona un Hotel"

    products: any[] = []
    products2: any[] = []

    ngOnInit(): void {
        this.listHotel();
        this.listHotelOffers();
    }

    listHotelOffers() {
        this.hotelOffersService.listHotelOffers().subscribe((data) => (this.products = data))
    }

    createHotelOffers(idHotel: number) {
        let post = {
            hotelId: idHotel,
            description: (document.getElementById('Descripcion') as HTMLInputElement).value,
            price: parseInt((document.getElementById('Precio') as HTMLInputElement).value)
        }
        this.hotelOffersService.createHotelOfferPost(post).subscribe({
            next: (response) => { this.listHotelOffers() }
        })
    }

    listHotel() {
        this.hotelService.listHotels().subscribe((data) => (this.products2 = data))
    }

    DeleteHotelOffer(id: number) {
        this.hotelOffersService.deleteHotelOffer(id).subscribe(() => { this.listHotel() })
    }
}
