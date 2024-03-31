import { HttpClient } from '@angular/common/http';
import { Injectable, Optional, inject } from '@angular/core';
import { IApiResponseRegister } from './Models/register.interface';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  URL_REGISTER = 'http://localhost:5094/api/identity/register';
  // URL_REGISTER = 'https://fakestoreapi.com/auth/login';

  httpClient = inject(HttpClient)

  constructor() {
    console.log('RegisterService');
  }

  

  getRegister(){

    let data: IApiResponseRegister = {
      id: '123',
      userName: 'nombreDeUsuario',
      email: 'correo@ejemplo.com',
      nacionality: 'Cuba',
      password: 'contraseñaSegura123'
  };

    return this.httpClient.post<IApiResponseRegister>(this.URL_REGISTER, data);
  }
}
