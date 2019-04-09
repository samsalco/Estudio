import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

// Rutas
import { APP_ROUTING } from './app.routes';

///Declaracion de componentes
import { AppComponent } from './app.component';
import { WebapitestComponent } from './components/unittest/webapitest/webapitest.component';
import { HomeComponent } from './components/home/home.component';
import { PatientsComponent } from './components/patients/patients.component';
import { MaterialComponent } from './components/material/material.component';
import { MedicineComponent } from './components/medicine/medicine.component';
import { LaboratoryComponent } from './components/laboratory/laboratory.component';
import { ProtocolComponent } from './components/protocol/protocol.component';
import { NavbarComponent } from './components/navbar/navbar.component';



@NgModule({
  declarations: [
    AppComponent,
    WebapitestComponent,
    HomeComponent,
    PatientsComponent,
    MaterialComponent,
    MedicineComponent,
    LaboratoryComponent,
    ProtocolComponent,
    NavbarComponent    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    APP_ROUTING,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
