using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class UtilisateurForEditReponse
    {
        public UtilisateurReponse Utilisateur { get; set; }
        public IEnumerable<SiteOperationForListVm>  SiteOperations { get; set; }
        public IEnumerable<LangueForListeVm> Langues { get; set; }
        public IEnumerable<ProfileforListeVm> Profiles { get; set; }
    }
}
