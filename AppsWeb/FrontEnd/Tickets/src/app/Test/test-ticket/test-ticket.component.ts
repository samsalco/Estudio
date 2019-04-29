import { Component, OnInit } from '@angular/core';
import { TicketService } from '../../Services/ticket.service';
import { RequestResult } from 'src/app/Models/request-result';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-test-ticket',
  templateUrl: './test-ticket.component.html',
  styleUrls: ['./test-ticket.component.css']
})
export class TestTicketComponent implements OnInit {

  constructor(private ticketService: TicketService) { }

  ngOnInit() {
  }

  GetTickets() {
    let result: RequestResult = null;

    console.log("Inicio llamado al servicio");
    this.ticketService
      .GetTicket()
      .subscribe(data => {
        result = data as RequestResult;
        console.log(result);
      }, error => console.log(error));
    
    console.log("Finalización llamado al servicio");
  }
}
