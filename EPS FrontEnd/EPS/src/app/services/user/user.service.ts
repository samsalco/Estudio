import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from 'src/app/models/User/user';
import { RequestResponse } from 'src/app/models/Common/request-response';

@Injectable({
  providedIn: 'root'
})
export class UserService
{
  ///Constructor de clase
  constructor(private http: HttpClient) { }

  ///Obtener todos los usuarios
  GetAllUsers()
  {
    return this.http.get('http://localhost:34844/api/user');
  }


  ///Obtener todos los usuarios
  GetUser(id: string, password: string)
  {
    return this.http.get('http://localhost:34844/api/user/' + id + '/' + password);
  }

  ///Adicionar usuario
  PostUser(user: User)
  {
    return this.http.post<RequestResponse>('http://localhost:34844/api/user', user);
  }

}
