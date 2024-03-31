import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IApiCreateHotel, IApiListHotel } from './Models/listAgency.interface';

@Injectable({
    providedIn: 'root'
})
export class HotelService {

    constructor(private http: HttpClient) { }

    createHotelPost(data: IApiCreateHotel) {
        return this.http.post('http://localhost:5094/api/Hotel/create', data)
    }

    deleteHotel(hotelId: number) {
        const url = `${'http://localhost:5094/api/Hotel'}/delete?hotel=${hotelId}`
        return this.http.delete(url)
    }

    httpClient = inject(HttpClient)
    listHotels() {
        return this.httpClient.get<IApiListHotel[]>('http://localhost:5094/api/Hotel/list')
    }
}
