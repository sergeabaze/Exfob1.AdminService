using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Exfob.Core.Interfaces.Administrations.Securites
{
    public  interface IUtilisateurRepository : IGenericDapperRepository<Utilisateur>
    {
        Task<IEnumerable<Utilisateur>> GetListe(int siteOperationid);
        Task<Utilisateur> GetById(int Id);
        Task<UtilisateurEdit> GetEditById(int Id, int societeId);
        Task<int> Creation(Utilisateur entity);
        Task Update(Utilisateur entity);
        Task UpdatePassWord(int UtilisateurID, string NewPassWord, string MisejourPar);
        Task UpdateActivateAccount(int UtilisateurID, bool EstActif, string MisejourPar);
        Task Delete(int id);
        Task<UtilisateurLoginModel> GetLoggin(string NomUtilisateur, string MotPasse);
    }
}

