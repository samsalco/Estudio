import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderService
{

  ///Constructor de clase
  constructor(private http: HttpClient) { }

  ///Obtener ordenes de un paciente
  GetPatientOrders(history: number, tipo: string)
  {
    return this.http.get('http://localhost:34844/api/order/' + history + '/' + tipo);
  }

}
