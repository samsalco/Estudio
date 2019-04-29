import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestResult } from '../Models/request-result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private ticketService: HttpClient)
  {    
  }

  //Consultar todos los tickets
  GetTicket() {
    return this.ticketService.get('http://localhost:21195/api/tickets');
  }
}
