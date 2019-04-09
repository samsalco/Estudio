import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/Patient/patient.service';
import { FormsModule } from '@angular/forms';
import { Patient } from 'src/app/models/Patient/patient';
import { RequestResponse } from 'src/app/models/Common/request-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html'
})
export class PatientsComponent implements OnInit {

  constructor(private patientService: PatientService, private router: Router) { }

  history: string;
  patient: Patient;
  requestResponse: RequestResponse;

  ngOnInit() {}

  ///Obtener la informcion del paciente
  GetPatient()
  {
    console.log('Inicia Llamado a GetPatien');

   
    this.patientService.GetPatient(this.history).subscribe(result => {

      this.requestResponse = result as RequestResponse;
      this.patient = this.requestResponse.Result as Patient;

      console.log(this.patient);

    }, error => console.error(error));

    console.log('Termina Llamado a GetPatien');
  }

  Medicines()
  {
    this.router.navigate(['/medicines', this.history]);
  }
}
