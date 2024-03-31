import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiRegister } from './Models/listAgency.interface';
import { tap } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RegisterService {
    private url = 'http://localhost:5094/api/identity/register'

    constructor(private http: HttpClient) { }

    registerPost(data: IApiRegister) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'text/plain'
        })
        return this.http.post(this.url, data, { headers, responseType: 'text' }).pipe(tap(res => {
            localStorage.setItem('access_token', res);
        }))
    }
}