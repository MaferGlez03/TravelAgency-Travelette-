import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PackageBodyOffersComponent } from './package-body-offers/package-body-offers.component';
import { SortBlockPackageComponent } from './sort-block-package/sort-block-package.component';

@Component({
    selector: 'app-package-body',
    standalone: true,
    imports: [RouterModule, PackageBodyOffersComponent, SortBlockPackageComponent],
    templateUrl: './package-body.component.html',
    styleUrl: './package-body.component.css'
})
export class PackageBodyComponent {

}
