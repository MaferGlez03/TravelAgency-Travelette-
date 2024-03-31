import { Component } from '@angular/core';
import { LoginComponent } from '../../login/login.component';
import { SignupComponent } from '../../register/signup.component';
import { RouterOutlet } from '@angular/router';
import { RouterModule } from '@angular/router'
import { IdService } from '../../Services/MovimientoDatos/id.service';

@Component({
    selector: 'app-header-in',
    standalone: true,
    imports: [RouterOutlet, LoginComponent, SignupComponent, RouterModule],
    templateUrl: './header-in.component.html',
    styleUrl: './header-in.component.css'
})
export class HeaderInComponent {
    id: string | null = null;

    constructor(private idService: IdService) {
        this.idService.currentId.subscribe(id => {
            this.id = id;
        });
    }
}
