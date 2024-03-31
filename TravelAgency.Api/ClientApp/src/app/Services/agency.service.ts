import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IApiCreateAgency, IApiListAgency } from './Models/listAgency.interface';

@Injectable({
    providedIn: 'root'
})
export class AgencyService {

    constructor(private http: HttpClient) { }

    createAgencyPost(data: IApiCreateAgency) {
        return this.http.post('http://localhost:5094/api/Agency/create', data)
    }

    httpClient = inject(HttpClient)
    listAgencies() {
        const token = localStorage.getItem('access_token'); // Obtiene el token de acceso del localStorage
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        return this.http.get<IApiListAgency[]>('http://localhost:5094/api/Agency/list', { headers })
    }

    deleteAgency(id: number) {
        return this.http.delete(`http://localhost:5094/api/Agency/delete?agencyId=${id}`)
    }

    updateAgency(id: number, datos: IApiCreateAgency) {
        return this.http.put(`http://localhost:5094/api/Agency/update?agencyId=${id}`, datos)
    }
}
