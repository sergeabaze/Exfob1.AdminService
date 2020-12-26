using Exfob.Models.Administration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exfob.Infrastructure.Tests.Fixtures
{
    public abstract class GestionBoisContextTests
    {
        protected GestionBoisContextTests(DbContextOptions<GestionBoisContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }
        protected DbContextOptions<GestionBoisContext> ContextOptions { get; }
        private void Seed()
        {
            using (var context = new GestionBoisContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Profils.Add(new Profil { ProfilID = 1, Libelle = "Fr" });

                context.Modules.Add(new Module { ModuleID  = 1, ModuleParentID =1, Libelle = "user" });
                context.Droits.Add(new Droit { DroitID =1, ProfilID =1, ModuleID =1, Ecriture=true , Modifier =true, Suppression =true , Lecture =true });
                context.Langues.Add(new Langue { LangueID = 1, Code = "code123", Libelle = "Langue123" });
                context.NatureSites.Add(new NatureSite { NatureSiteID = 1, Code = "st", Libelle = "site" });
                context.Groupes.Add(new Groupe { GroupeID = 1, Code = "st", Libelle = "site" });
                context.Sieges.Add(new Siege { SiegeID = 1, Code = "st", Libelle = "site", GroupeID = 1, Adresse = "Adresse2365" });
                context.Societes.Add(new Societe
                {
                    SocieteID = 1,
                    SiegeID = 1,
                    NumIdentite = "NumIdentite123",
                    Code = "st",
                    Libelle = "site",
                    Description = "",
                    Adresse = "",
                    BoitePostale = ""
                });

                context.SiteOperations.Add(new SiteOperation
                {
                    SiteOperationID = 1,
                    NatureSiteID = 1,
                    PaysID = 1,
                    SiegeID = 1,
                    SocieteID = 1,
                    Libelle = "Libelle123",
                    Code = "Code222",
                    Adresse = "Adresse222",
                    Activite = true,

                });

                var user1 = new Utilisateur
                {
                    UtilisateurID = 1,
                    LangueID = 1,
                    ProfilID = 1,
                    SiteOperationID = 1,
                    LoginUtilisateur = "Teste",
                    MotPasseHash = "eee",
                    SelMotdePasse = "",
                    Email = "xxx@yahoo.fr",
                    CreerPar = "dd",
                    Matricule = "Matricule123",
                    Nom = "Nom123",
                    Fonction = "Fonction123",
                    EstActif = true,


                };

                context.Utilisateurs.AddRange(user1);
                context.SaveChanges();
            }

            //[Fact]
            //public void Can_get_item()
            //{
            //    using (var context = new GestionBoisContext(ContextOptions))
            //    {
            //        var controller = new GestionBoisContext(context);

            //        var item = controller.Get("ItemTwo");

            //        Assert.Equal("ItemTwo", item.Name);
            //    }
            //}
        }
    }
}
