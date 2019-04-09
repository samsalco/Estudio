import { ProtocolItem } from './protocol-item';

export class ProtocolRequest
{
  UserCode: string;
  /// <summary>
  /// Historia
  /// </summary>
  History: number;
  /// <summary>
  /// Listado de protocolos
  /// </summary>
  Protocols: ProtocolItem[];
}
