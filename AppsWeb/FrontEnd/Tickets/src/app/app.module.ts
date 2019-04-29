//Importa modulos de angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule,Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//Importamos los componentes que vamos a usar
import { AppComponent } from './app.component';
import { TicketsComponent } from './Components/tickets/tickets.component';
import { TestTicketComponent } from './Test/test-ticket/test-ticket.component';
import { TicketFormComponent } from './Components/ticket-form/ticket-form.component';


//Reglas de ruteo
const appRoutes: Routes = [  
  { path: 'tickets', component: TicketsComponent },  
  { path: '**', redirectTo:'/', pathMatch: 'full'}

]


@NgModule({
  declarations: [
    AppComponent,
    TicketsComponent,
    TestTicketComponent,
    TicketFormComponent
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes, { enableTracing: true } //<--- Solo con el proposito de debug
    ),
    BrowserModule,
    HttpClientModule,    
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [TicketFormComponent]
})
export class AppModule { }
