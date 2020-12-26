using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Interfaces.Administrations.Securites
{
    public  interface IUtilisateurRepository : IGenericDapperRepository<Utilisateur>
    {
        Task<IEnumerable<Utilisateur>> GetListe(int siteOperationid);
        Task<Utilisateur> GetById(int Id);
        Task<int> Creation(Utilisateur entity);
        Task Update(Utilisateur entity);
        Task Delete(int id);
    }
}
