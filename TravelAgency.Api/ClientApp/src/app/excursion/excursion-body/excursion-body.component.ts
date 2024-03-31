import { Component } from '@angular/core';
import { SortBlockExcursionComponent } from './sort-block-excursion/sort-block-excursion.component';
import { ExcursionBodyOffersComponent } from './excursion-body-offers/excursion-body-offers.component';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-excursion-body',
    standalone: true,
    imports: [SortBlockExcursionComponent, ExcursionBodyOffersComponent, RouterModule],
    templateUrl: './excursion-body.component.html',
    styleUrl: './excursion-body.component.css'
})
export class ExcursionBodyComponent {

}
