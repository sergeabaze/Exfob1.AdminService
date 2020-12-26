using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Services.Administration
{
    public  interface IUtilisateurService
    {
        Task<IEnumerable<Utilisateur>> ObtenireUtilisateurListe(int siteOperationId);
        Task<Utilisateur> ObtenireUtilisateurParId(int Id);
        Task<int> CreationUtilisateur(Utilisateur entity);
        Task MisejourUtilisateur(Utilisateur entity);
        Task SuppressionUtilisateur(int id);

       
    }
}
