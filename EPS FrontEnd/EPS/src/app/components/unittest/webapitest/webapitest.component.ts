import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user/user.service';
import { RequestResponse } from 'src/app/models/Common/request-response';
import { User } from 'src/app/models/User/user';
import { ProtocolRequest } from 'src/app/models/Protocol/protocol-request';
import { ProtocolItem } from 'src/app/models/Protocol/protocol-item';
import { Material } from 'src/app/models/Material/material';
import { ProtocolService } from 'src/app/services/Protocol/protocol.service';
import { Medicine } from 'src/app/models/Medicine/medicine';
import { Laboratory } from 'src/app/models/Laboratory/laboratory';
import { OrderService } from 'src/app/services/Order/order.service';
import { Protocol } from 'src/app/models/Protocol/protocol';
import { PatientService } from 'src/app/services/Patient/patient.service';
import { Patient } from 'src/app/models/Patient/patient';

@Component({
  selector: 'app-webapitest',
  templateUrl: './webapitest.component.html'
})
export class WebapitestComponent implements OnInit {

  constructor(private userService: UserService, private protocolService: ProtocolService, private orderService: OrderService, private patientService: PatientService) { }

  ngOnInit() {
  }

  //Obtener todos los usuarios
  GetAllUsers() {
    console.log('Inicia Llamado a GetAllUser');

    let requestResponse: RequestResponse;

    this.userService.GetAllUsers().subscribe(result => {

      requestResponse = result as RequestResponse;
      //console.log(requestResponse);
      console.log(requestResponse.Message);
      console.log(requestResponse.Result);
      console.log(requestResponse.Successful);

    }, error => console.error(error));

    console.log('Termina Llamado a GetAllUser');

  }

  //Obtener un usuario
  GetUser() {
    console.log('Inicia Llamado a GetUser');

    let requestResponse: RequestResponse;

    this.userService.GetUser('vfranco', '54321').subscribe(result => {

      requestResponse = result as RequestResponse;
      //console.log(requestResponse);
      console.log(requestResponse.Message);
      console.log(requestResponse.Result);
      console.log(requestResponse.Successful);

    }, error => console.error(error));

    console.log('Termina Llamado a GetUser');
  }

  ///Adicionar usuario
  PostUser() {
    let user: User =
    {
      Code: 'cosorio',
      Name: 'Carlos Osorio',
      Password: '123',
      State: 'A'
    }

    let requestResponse: RequestResponse;


    this.userService.PostUser(user).subscribe(result => {
      requestResponse = result as RequestResponse;
      console.log(requestResponse);
    }, error => console.error(error));


  }

  ///Adicionar un protocolo
  PostProtocol() {

    console.log('Inicia llamado protocolo');

    let material: Material =
    {
      Code: '01',
      Name: 'Tijeras',
      Comments: 'Material desde Angular',
      Presentation: 'UN',
      Quantity: 1,
      Type: 'MATE',
      Sequence: 0
    }
    let medicine: Medicine =
    {
      Code: '01',
      Name: 'Acetaminofen',
      Dose: 2,
      Duration: '10',
      Frecuency: '3D',
      Posology: 'Posologia del medicamento',
      Type: 'MEDI',
      Unity: 'TB',
      Comments: 'Comentarios medicamento desde Angular',
      Sequence:0
    }
    let laboratory: Laboratory =
    {
      Code: '01',
      Name: 'Rayos X',
      Frecuency: '10',
      Quantity: 5,
      Type: 'LABO',
      Comments: 'Laboratorio desde Angular',
      Sequence:0
    }
    let protocolItems: ProtocolItem[] =
      [
        { ActivityJson: JSON.stringify(material), ActivityType: 'MATE' },
        { ActivityJson: JSON.stringify(medicine), ActivityType: 'MEDI' },
        { ActivityJson: JSON.stringify(laboratory), ActivityType: 'LABO' }
      ]
    let protocolRequest: ProtocolRequest =
    {
      History: 1,
      UserCode: 'vfranco',
      Protocols: protocolItems
    }

    let requestResponse: RequestResponse;
    
    this.protocolService.PostProtocol(protocolRequest).subscribe(result =>
    {
        requestResponse = result as RequestResponse;
      console.log(requestResponse);
    }, error => console.error(error));

    console.log('Termina llamado protocolo');
  }

  ///Obtener las ordenes de un paciente
  PatientOrders()
  {
    console.log('Inicia llamado obtener ordenes');

    ///Listado de Ordenes del paciente
    let orderList: any[] = [];
    
    let requestResponse: RequestResponse;

    this.orderService.GetPatientOrders(1, 'all').subscribe(result =>
    {
      requestResponse = result as RequestResponse;

      for (let order of requestResponse.Result)
      {
        switch (order.Type)
        {
          case 'PROT':
            let newProtocolo: Protocol = { Sequence: order.Order.Sequence, Orders: [] };
            for (let activity of order.Order.Orders)
            {
              switch (activity.Type)
              {
                case 'LABO':
                  let newLaboratory = activity as Laboratory;
                  newProtocolo.Orders.push(newLaboratory);
                  break;
                case 'MATE':
                  let newMaterial = activity as Material;
                  newProtocolo.Orders.push(newMaterial);
                  break;
                case 'MEDI':
                  let newMedicine = activity as Medicine;
                  newProtocolo.Orders.push(newMedicine);
                  break;
                default:
              }              
            }
            orderList.push(newProtocolo);
            break;
          case 'MEDI':
            let medicine = order.Order as Medicine;
            orderList.push(medicine);
            break;
          case 'LABO':
            let laboratory = order.Order as Laboratory;
            orderList.push(laboratory);
            break;
          case 'MATE':
            let material = order.Order as Material;
            orderList.push(material);
            break;
          default:
        }
      }

      console.log(orderList);

    }, error => console.error(error));

    console.log('termina llamado obtener ordenes');
  }

  ///Obtener paciente
  GetPatient()
  {
    console.log('Inicia Llamado a GetPatien');

    let requestResponse: RequestResponse;
    let patient: Patient;

    this.patientService.GetPatient('3').subscribe(result => {

      requestResponse = result as RequestResponse;
      patient = requestResponse.Result as Patient;
      //console.log(requestResponse.Message);
      //console.log(requestResponse.Result);
      //console.log(requestResponse.Successful);
      console.log(patient);

    }, error => console.error(error));

    console.log('Termina Llamado a GetPatien');
  }
}
