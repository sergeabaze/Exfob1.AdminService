namespace Exfob.Service.Traducteurs.Administration.Securiter
{
    public class UtilisateurTraducteur : IUtilisateurTraducteur
    {
       /* public UtilisateurLogin FromEntityToLoginModel(Utilisateur entity)
        {
            var model = new UtilisateurLogin();
            return model;
        }

        public IEnumerable<UtilisateurList> FromEntityToModel(IEnumerable<Utilisateur> entity)
        {
            if (!entity.Any())
                return null;


            return (from val in entity
                    select new UtilisateurList
                    {
                        UtilisateurID = val.UtilisateurID,
                        Nom = val.Nom,
                        Email = val.Email,
                        EstActif = val.EstActif,
                        Langue = null,
                        Matricule = val.Matricule,
                        profile = null
                    });
        }


        public UtilisateurReponse FromEntityToModel(Utilisateur entity)
        {
            if (entity == null)
                return null;

            var model = new UtilisateurReponse
            {
                UtilisateurID = entity.UtilisateurID,
                Nom = entity.Nom,
                ProfilID = entity.ProfilID,
                LangueID = entity.LangueID,
                SiteOperationID = entity.SiteOperationID,
                Matricule = entity.Matricule,
                CreerPar = entity.CreerPar,
                Email = entity.Email,
                EstActif = entity.EstActif,
                Fonction = entity.Fonction,
                LoginUtilisateur = entity.LoginUtilisateur,
                DateCreation = entity.DateCreation,
                DateMisejour = entity.DateMisejour,
                MiseJourPar = entity.MiseJourPar,
                MotPasseHash = entity.MotPasseHash,
                SelMotdePasse = entity.SelMotdePasse
            };
            return model;
        }

        public Utilisateur FromModelToEntity(UtilisateurEdit model)
        {
            if (model == null)
                return null;

            var entity = new Utilisateur
            {
                UtilisateurID = model.UtilisateurID,
                Nom = model.Nom,
                ProfilID = model.ProfilID,
                LangueID = model.LangueID,
                SiteOperationID = model.SiteOperationID,
                Matricule = model.Matricule,
                Email = model.Email,
                EstActif = model.EstActif,
                Fonction = model.Fonction,
                LoginUtilisateur = model.LoginUtilisateur,
                MiseJourPar = model.MiseJourPar,
                MotPasseHash = model.MotPasseHash,
                SelMotdePasse = model.SelMotdePasse
            };
            return entity;
        }

        public Utilisateur FromModelToEntity(UtilisateurCreate model)
        {
            if (model == null)
                return null;

            var entity = new Utilisateur
            {
              
                Nom = model.Nom,
                ProfilID = model.ProfilID,
                LangueID = model.LangueID,
                SiteOperationID = model.SiteOperationID,
                Matricule = model.Matricule,
                Email = model.Email,
                EstActif = model.EstActif,
                Fonction = model.Fonction,
                LoginUtilisateur = model.LoginUtilisateur,
                CreerPar = model.CreerPar,
                MotPasseHash = model.MotPasseHash,
                SelMotdePasse = model.SelMotdePasse
            };
            return entity;
        }*/
    }
}
