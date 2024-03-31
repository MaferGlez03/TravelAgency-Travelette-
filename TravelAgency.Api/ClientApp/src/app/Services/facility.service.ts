import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IApiCreateFacility, IApiListFacility } from './Models/listAgency.interface';

@Injectable({
    providedIn: 'root'
})
export class FacilityService {

    constructor(private http: HttpClient) { }

    createFacility(data: IApiCreateFacility) {
        return this.http.post('http://localhost:5094/api/Facility/create', data)
    }

    deleteFacility(facilityId: number) {
        const url = `${'http://localhost:5094/api/Facility'}/delete?facility=${facilityId}`
        return this.http.delete(url)
    }

    httpClient = inject(HttpClient)
    
    listFacility() {
        return this.httpClient.get<IApiListFacility[]>('http://localhost:5094/api/Facility/list')
    }
}
