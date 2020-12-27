using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
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
        Task<UtilisateurEdit> ObtenireUtilisateurEditParId(int Id, int SocieteId);
        Task<UtilisateurLoginModel> ObtenireLoggin(string NomUtilisateur, string MotPasse);
        Task MisejourPourActivationDuCompte(int UtilisateurID, bool EstActif, string MisejourPar);
        Task MiseJourDuMotDePasse(int UtilisateurID, string NewPassWord, string MisejourPar);



    }
}
