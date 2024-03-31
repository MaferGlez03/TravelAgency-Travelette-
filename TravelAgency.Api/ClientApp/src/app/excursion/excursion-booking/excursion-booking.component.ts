import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ExcursionBookingDetailsComponent } from './excursion-booking-details/excursion-booking-details.component';

@Component({
    selector: 'app-excursion-booking',
    standalone: true,
    imports: [RouterModule, ExcursionBookingDetailsComponent],
    templateUrl: './excursion-booking.component.html',
    styleUrl: './excursion-booking.component.css'
})
export class ExcursionBookingComponent {

}
