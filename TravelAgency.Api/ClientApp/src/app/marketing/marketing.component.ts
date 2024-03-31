import { FacilityService } from '../Services/facility.service';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ExcursionService } from '../Services/excursion.service';

@Component({
    selector: 'app-marketing',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './marketing.component.html',
    styleUrl: './marketing.component.css'
})
export class MarketingComponent {

    constructor(private facilityService: FacilityService,
        private excursionService: ExcursionService) { }

    products: any[] = []
    show = ''

    showAddPackage() {
        this.show = 'AddPackage'
    }

    showAddExcursion() {
        this.show = 'AddExcursion'
    }

    showAddBooking() {
        this.show = 'AddBooking'
    }

    showAddFacilities() {
        this.show = 'AddFacilities'
    }

    showNothing() {
        this.show = ''
    }

    listFacility() {
        this.facilityService.listFacility().subscribe((data) => (this.products = data))
        this.show = 'facility'
    }

    deleteFacility(facilityID: number) {
        this.facilityService.deleteFacility(facilityID).subscribe(() => { this.listFacility() })
        this.show = 'facility'
    }

    createFacility() {
        let post = {
            name: (document.getElementById('Nombre') as HTMLInputElement).value
        }

        this.facilityService.createFacility(post).subscribe({
            next: (response) => { }
        })
        this.showNothing()
    }

    createExcursion() {
        let post = {
            id: 0,
            name: (document.getElementById('Nombre') as HTMLInputElement).value,
            capacity: parseInt((document.getElementById('Capacity') as HTMLInputElement).value),
            price: parseInt((document.getElementById('Price') as HTMLInputElement).value),
            arrivalDate: new Date((document.getElementById('arrivalDate') as HTMLInputElement).value),
            departureDate: new Date((document.getElementById('departureDate') as HTMLInputElement).value),
            arrivalPlace: (document.getElementById('arrivalPlace') as HTMLInputElement).value,
            departurePlace: (document.getElementById('departurePlace') as HTMLInputElement).value,
            guia: (document.getElementById('Guia') as HTMLInputElement).value
        }

        this.excursionService.createExcursion(post).subscribe({
            next: (response) => { this.showNothing() }
        })
    }

    excursions: any[] = []

    listExcursion() {
        this.excursionService.listExcursion().subscribe((data) => {
            this.excursions = data
            this.show = 'excursion'
        })
    }

    deleteExcursion(id: number) {
        this.excursionService.deleteExcursion(id).subscribe(() => this.listExcursion())
    }
}
