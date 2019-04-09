import { Material } from './material';

///Parametros peticion material
export class MaterialRequest
{
  UserCode: string;
  /// <summary>
  /// Historia
  /// </summary>
  History: number;
  /// <summary>
  /// Medicamento
  /// </summary>
  Material: Material;
}
