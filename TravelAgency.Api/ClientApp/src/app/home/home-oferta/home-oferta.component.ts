import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HotelService } from '../../Services/hotel.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-home-oferta',
    standalone: true,
    imports: [RouterModule, CommonModule],
    templateUrl: './home-oferta.component.html',
    styleUrl: './home-oferta.component.css'
})
export class HomeOfertaComponent implements OnInit {

    constructor(private hotelService: HotelService) { }

    products: any[] = []

    ngOnInit(): void {
        this.hotelService.listHotels().subscribe((data) => (this.products = data))
    }


}
