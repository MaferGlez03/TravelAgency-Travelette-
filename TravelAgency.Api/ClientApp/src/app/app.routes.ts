import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './register/signup.component';
import { AdminComponent } from './admin/admin.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { ExcursionComponent } from './excursion/excursion.component';
import { HotelOffersComponent } from './hotel-offers/hotel-offers.component';
import { HotelOfferBookingComponent } from './hotel-offers/hotel-offer-booking/hotel-offer-booking.component';
import { HotelStaffComponent } from './hotel-staff/hotel-staff.component';
import { MarketingComponent } from './marketing/marketing.component';
import { ExcursionBookingComponent } from './excursion/excursion-booking/excursion-booking.component';
import { PackageComponent } from './package/package.component';
import { PackageBookingComponent } from './package/package-booking/package-booking.component';


export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'admin', component: AdminComponent },
    { path: 'excursion', component: ExcursionComponent },
    { path: 'hotel', component: HotelOffersComponent },
    { path: 'hotel/booking', component: HotelOfferBookingComponent },
    { path: 'staff', component: HotelStaffComponent },
    { path: 'staff', component: HotelStaffComponent },
    { path: 'marketing', component: MarketingComponent },
    { path: 'package', component: PackageComponent },
    { path: 'excursion/booking', component: ExcursionBookingComponent },
    { path: 'package/booking', component: PackageBookingComponent }

];

@NgModule({
    imports: [RouterModule.forRoot(routes), HttpClientModule],
    exports: [RouterModule]
})
export class AppRoutingModule { }

