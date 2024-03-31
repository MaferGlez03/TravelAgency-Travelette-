import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ExcursionService } from '../../Services/excursion.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-home-excursion',
    standalone: true,
    imports: [RouterModule, CommonModule],
    templateUrl: './home-excursion.component.html',
    styleUrl: './home-excursion.component.css'
})
export class HomeExcursionComponent implements OnInit {

    constructor(private excursionService: ExcursionService) { }

    products: any[] = []

    ngOnInit(): void {
        this.excursionService.listExcursion().subscribe((data) => (this.products = data))
    }
}
