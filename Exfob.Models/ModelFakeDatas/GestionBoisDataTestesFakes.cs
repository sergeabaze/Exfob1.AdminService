using AutoFixture;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;

namespace Exfob.Models.Fakes
{
    public class GestionBoisDataTestesFakes
    {
        Fixture _fixture;
        public GestionBoisDataTestesFakes()
        {
            _fixture = new Fixture();
        }
        public Utilisateur GetUtilisateur()
        {

            return _fixture.Build<Utilisateur>()
                   .With(x => x.Langue, (Langue)null)
                   .With(x => x.Profil, (Profil)null)
                   .With(x => x.MiseJourPar, "")
                   .With(x => x.LangueID, 1)
                   .With(x => x.ProfilID, 1)
                   .With(x => x.SiteOperationID, 1)
                   .With(x => x.DateMisejour, (DateTime?)null)
                   .With(x => x.SiteOperation, (SiteOperation)null)
                   .With(x => x.SiteAutorises, (List<SiteAutorise>)null)
                .Create();
        }

        public Langue GetLangue()
        {
            return _fixture.Build<Langue>()
                .With(x => x.Utilisateurs, (List<Utilisateur>)null)
                .Create();
        }



        public Profil GetProfil()
        {
            return _fixture.Build<Profil>()
               .With(x => x.Droits, new List<Droit>())
               .With(x => x.Utilisateurs, new List<Utilisateur>())
               .Create();
        }

        public static ProfilAutorise GetProfilAutorise()
        {
            return new ProfilAutorise { ProfilAutoriseID = 1, Libelle = "mater123" };
        }

        public NatureSite GetNatureSite()
        {
            return _fixture.Build<NatureSite>()
              .With(x => x.SiteArrives, (List<SiteArrive>)null)
              .Create();
        }

        public SiteArrive GetSiteArrive()
        {
            return _fixture.Build<SiteArrive>()
                .With(x => x.NatureSiteID, 1)
                .With(x => x.SocieteID, 1)
                .With(x => x.PaysID, 1)
                .With(x => x.PortID, 1)
                .With(x => x.Societe, (Societe)null)
                .With(x => x.Pay, (Pays)null)
                .With(x => x.Port, (Port)null)
                .Create();
        }

        public static Groupe GetGroupe()
        {
            return new Groupe { GroupeID = 1, Code = "st", Libelle = "site" };
        }

        public static Siege GetSiege()
        {
            return new Siege { SiegeID = 1, Code = "st", Libelle = "site", GroupeID = 1, Adresse = "Adresse2365" };
        }

        public static Societe GetSociete()
        {
            return new Societe
            {
                SocieteID = 1,
                SiegeID = 1,
                NumIdentite = "NumIdentite123",
                Code = "st",
                Libelle = "site",
                Description = "",
                Adresse = "",
                BoitePostale = ""
            };
        }

        public static SiteOperation GetSiteOperation()
        {
            return new SiteOperation
            {
                SiteOperationID = 1,
                NatureSiteID = 1,
                PaysID = 1,
                SiegeID = 1,
                SocieteID = 1,
                Libelle = "Libelle123",
                Code = "Code123",
                Adresse = "Adresse123",
                Activite = true,

            };
        }
    }
}
