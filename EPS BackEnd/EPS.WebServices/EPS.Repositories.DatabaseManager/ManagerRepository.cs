using EPS.Common.Models;
using System;
using System.Threading.Tasks;

namespace EPS.Repositories.DatabaseManager
{
    public class ManagerRepository<T, K> : RepositoryBase<T, K>
    {
        #region members
        //repositorio
        readonly object repository;
        //Tipo de repositorio
        readonly ManagerRepositoryType repositoryType;
        #endregion
        #region 
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        public ManagerRepository(string name, RepositoryDatabaseProvider provider, string connectionString)
        {
            switch (name)
            {
                case "AllUsers":
                    repositoryType = ManagerRepositoryType.AllUsers;
                    repository = new UsersRepository(provider, connectionString);
                    break;
                case "User":
                    repositoryType = ManagerRepositoryType.User;
                    repository = new UserRepository(provider, connectionString);
                    break;
                case "PostUser":
                    repositoryType = ManagerRepositoryType.PostUser;
                    repository = new UserPostRepository(provider, connectionString);
                    break;
                case "Patient":
                    repositoryType = ManagerRepositoryType.Patient;
                    repository = new PatientRepository(provider, connectionString);
                    break;
                case "ProtocolPost":
                    repositoryType = ManagerRepositoryType.ProtocolPost;
                    repository = new ProtocolPostRepository(provider, connectionString);
                    break;
                case "LaboratoryPost":
                    repositoryType = ManagerRepositoryType.LaboratoryPost;
                    repository = new LaboratoryPostRepository(provider, connectionString);
                    break;
                case "LaboratoryPostAsync":
                    repositoryType = ManagerRepositoryType.LaboratoryPostAsync;
                    repository = new LaboratoryPostRepository(provider, connectionString);
                    break;
                case "MaterialPost":
                    repositoryType = ManagerRepositoryType.MaterialPost;
                    repository = new MaterialPostRepository(provider, connectionString);
                    break;
                case "MedicinePost":
                    repositoryType = ManagerRepositoryType.MedicinePost;
                    repository = new MedicinePostRepository(provider, connectionString);
                    break;
                case "OrderGet":
                    repositoryType = ManagerRepositoryType.OrderGet;
                    repository = new OrderGetRepository(provider, connectionString);
                    break;
                default:
                    break;
            }
        }
        #endregion
        /// <summary>
        /// Obtener
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override T Get(K parameters)
        {
            switch (repositoryType)
            {
                case ManagerRepositoryType.AllUsers:
                    return (T)(object)((UsersRepository)repository).Get(parameters);
                case ManagerRepositoryType.User:
                    return (T)(object)((UserRepository)repository).Get(parameters as Tuple<string, string>);
                case ManagerRepositoryType.Patient:
                    return (T)(object)((PatientRepository)repository).Get(parameters as string);
                case ManagerRepositoryType.OrderGet:
                    return (T)(object)((OrderGetRepository)repository).Get(parameters as Tuple<int, string>);
                default:
                    break;
            }
            return base.Get(parameters);
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override int Delete(K data)
        {
            return base.Delete(data);
        }
        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override T Post(K data)
        {
            switch (repositoryType)
            {
                case ManagerRepositoryType.PostUser:
                    return (T)(object)((UserPostRepository)repository).Post(data as User);
                case ManagerRepositoryType.ProtocolPost:
                    return (T)(object)((ProtocolPostRepository)repository).Post(data as ProtocolRequest);
                case ManagerRepositoryType.LaboratoryPost:
                    return (T)(object)((LaboratoryPostRepository)repository).Post(data as LaboratoryRequest);
                case ManagerRepositoryType.MaterialPost:
                    return (T)(object)((MaterialPostRepository)repository).Post(data as MaterialRequest);
                case ManagerRepositoryType.MedicinePost:
                    return (T)(object)((MedicinePostRepository)repository).Post(data as MedicineRequest);
                default:
                    break;
            }
            return base.Post(data);
        }

        /// <summary>
        /// Adicionar Asincrono
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override async Task<T> PostAsync(K data)
        {
            switch (repositoryType)
            {
                case ManagerRepositoryType.LaboratoryPostAsync:
                    return await (Task<T>)(object)((LaboratoryPostRepository)repository).PostAsync(data as LaboratoryRequest);
                default:
                    break;
            }
            return base.Post(data);
        }
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override int Put(K data)
        {
            return base.Put(data);
        }
    }
}
