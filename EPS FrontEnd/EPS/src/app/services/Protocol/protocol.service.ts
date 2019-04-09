import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestResponse } from 'src/app/models/Common/request-response';
import { ProtocolRequest } from 'src/app/models/Protocol/protocol-request';

@Injectable({
  providedIn: 'root'
})
export class ProtocolService
{

  ///Constructor de clase
  constructor(private http: HttpClient) { }

  ///Adicionar usuario
  PostProtocol(protocolRequest: ProtocolRequest)
  {
    return this.http.post<RequestResponse>('http://localhost:34844/api/protocol', protocolRequest);
  }

}
