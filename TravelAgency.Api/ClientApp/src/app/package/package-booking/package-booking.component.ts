import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PackageBookingDetailsComponent } from './package-booking-details/package-booking-details.component';

@Component({
    selector: 'app-package-booking',
    standalone: true,
    imports: [PackageBookingDetailsComponent, RouterModule],
    templateUrl: './package-booking.component.html',
    styleUrl: './package-booking.component.css'
})
export class PackageBookingComponent {

}
