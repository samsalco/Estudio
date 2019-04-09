import { Laboratory } from './laboratory';

///Parametros de peticion de laboratorio
export class LaboratoryRequest
{
  /// <summary>
  /// Codigo
  /// </summary>
  UserCode: string;
  /// <summary>
  /// Historia
  /// </summary>
  History: number;
  /// <summary>
  /// Medicamento
  /// </summary>
  Laboratory: Laboratory;
}
