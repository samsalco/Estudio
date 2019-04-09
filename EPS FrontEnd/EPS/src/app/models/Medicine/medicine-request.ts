import { Medicine } from './medicine';

///Parametros peticion Medicamento
export class MedicineRequest
{
  UserCode: string;
  /// <summary>
  /// Historia
  /// </summary>
  History: number;
  /// <summary>
  /// Medicamento
  /// </summary>
  Medicine: Medicine;
}
