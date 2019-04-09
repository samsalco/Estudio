import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PatientService
{

  ///Constructor de clase
  constructor(private http: HttpClient) { }

  ///Obtener paciente
  GetPatient(history: string)
  {
    return this.http.get('http://localhost:34844/api/Patient/' + history);
  }

}
