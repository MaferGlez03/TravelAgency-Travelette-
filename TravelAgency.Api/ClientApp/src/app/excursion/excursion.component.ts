import { Component } from '@angular/core';
import { ExcursionBodyComponent } from './excursion-body/excursion-body.component';
import { ExcursionFiltersComponent } from './excursion-filters/excursion-filters.component';
import { ExcursionSearchComponent } from './excursion-search/excursion-search.component';
import { RouterModule } from '@angular/router';
import { SortBlockExcursionComponent } from './excursion-body/sort-block-excursion/sort-block-excursion.component';
import { ExcursionBodyOffersComponent } from './excursion-body/excursion-body-offers/excursion-body-offers.component';

@Component({
    selector: 'app-excursion',
    standalone: true,
    imports: [ExcursionBodyComponent, ExcursionFiltersComponent, ExcursionSearchComponent, RouterModule, SortBlockExcursionComponent, ExcursionBodyOffersComponent],
    templateUrl: './excursion.component.html',
    styleUrl: './excursion.component.css'
})
export class ExcursionComponent {

}
