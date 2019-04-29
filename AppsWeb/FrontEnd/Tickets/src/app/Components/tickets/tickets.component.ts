import { Component, OnInit } from '@angular/core';
import { TicketService } from 'src/app/Services/ticket.service';
import { Ticket } from 'src/app/Models/ticket';
import { error } from 'util';
import { RequestResult } from 'src/app/Models/request-result';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TicketFormComponent } from '../ticket-form/ticket-form.component';


@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})
export class TicketsComponent implements OnInit {
  listTickets: Ticket[];
  data: RequestResult;

  constructor(private ticketService: TicketService, private modalService: NgbModal) { }

  ngOnInit() {    
  }

  GetTickets() {    
    this.listTickets = [];
    this.ticketService.GetTicket().subscribe((result) => {
      this.data = result as RequestResult;
      if (this.data.Successful) {
        this.listTickets = this.data.Result;
      }
    }, error => console.log(error));
  }

  AddTicket() {
    const modal = this.modalService.open(TicketFormComponent);
    modal.result.then(
     this.handleModalTicketFormClose.bind(this),
      this.handleModalTicketFormClose.bind(this)
    )
  }

  handleModalTicketFormClose() {
    alert("Mensaje de prueba");
  }
}
