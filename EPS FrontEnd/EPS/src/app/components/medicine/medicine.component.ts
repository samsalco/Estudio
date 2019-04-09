import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { OrderService } from 'src/app/services/Order/order.service';
import { RequestResponse } from 'src/app/models/Common/request-response';
import { Medicine } from 'src/app/models/Medicine/medicine';

@Component({
  selector: 'app-medicine',
  templateUrl: './medicine.component.html'
})
export class MedicineComponent implements OnInit
{
  medicine: Medicine;
  id: string;

  constructor(private activatedRoute: ActivatedRoute, private orderService: OrderService)
  {

    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.PatientOrders(Number(this.id));
    });

    console.log(this.id);
  }


  PatientOrders(history:number) {
    console.log('Inicia llamado obtener ordenes');

    ///Listado de Ordenes del paciente
    let orderList: any[] = [];

    let requestResponse: RequestResponse;

    this.orderService.GetPatientOrders(history, 'MEDI').subscribe(result => {
      requestResponse = result as RequestResponse;

      for (let order of requestResponse.Result) {
       
            this.medicine = order.Order as Medicine;
            orderList.push(this.medicine);
            break;
        
      }

      console.log(orderList);

    }, error => console.error(error));

    console.log('termina llamado obtener ordenes');
  }


  ngOnInit() {
  }

}
