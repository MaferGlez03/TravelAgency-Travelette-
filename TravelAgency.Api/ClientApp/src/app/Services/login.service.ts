import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiLogin } from './Models/listAgency.interface';
import { Observable, tap } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoginService {

    private url = 'http://localhost:5094/api/identity/login'

    constructor(private http: HttpClient) { }

    loginPost(data: IApiLogin) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'text/plain'
        })

        return this.http.post(this.url, data, { headers, responseType: 'text' }).pipe(tap(res => {
            localStorage.setItem('access_token', res);
        }))
    }
}