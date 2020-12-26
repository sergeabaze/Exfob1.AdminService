using Exfob.Models.Administration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exfob.Infrastructure.Tests
{
    public class GestionBoisDbContextConfigureTest 
    {
        // public GestionBoisDbContextConfigureTest()
        protected  DbContextOptions<GestionBoisContext> ContextOptions { get; }


        public  GestionBoisDbContextConfigureTest(DbContextOptions<GestionBoisContext> contextOptions)
        {
            ContextOptions = contextOptions;
           // Seed();
        }

        private void Seed()
        {
            using (var context = new GestionBoisContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Profils.Add(new Profil {  ProfilID = 1, Libelle = "Fr" });
               // context.SaveChanges();
                context.Langues.Add(new Langue { LangueID = 1, Code = "", Libelle = ""});
                context.NatureSites.Add(new NatureSite { NatureSiteID = 1, Code = "st", Libelle = "site" });
                context.Groupes.Add(new Groupe { GroupeID = 1, Code = "st", Libelle = "site" });
                context.Sieges.Add(new Siege { SiegeID = 1, Code = "st", Libelle = "site",GroupeID=1 });
                context.Societes.Add(new Societe { SocieteID = 1, SiegeID =1, NumIdentite = "NumIdentite123", Code = "st", Libelle = "site" });
                context.Pays.Add(new Pay { PaysID = 1, SocieteID =1, CodePays ="",  CodePostal = "st",  NomPays = "site" });
                context.SiteOperations.Add(new SiteOperation { SiteOperationID =1, NatureSiteID =1, PaysID =1, SiegeID =1,
                 SocieteID =1, Libelle  = "Libelle123"
                });
                //  context.SaveChanges();

                var user1 = new Utilisateur { UtilisateurID = 1, LangueID =1, ProfilID =1, SiteOperationID =1,
                 LoginUtilisateur ="Teste", MotPasseHash ="eee", SelMotdePasse ="", Email ="xxx@yahoo.fr",
                 CreerPar ="dd", Matricule = "Matricule123", Nom = "Nom123", Fonction = "Fonction123",
                  EstActif = true, Langue = new Langue { LangueID =1, Code="", Libelle =""},
                 
                };

                context.Utilisateurs.AddRange(user1);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            
            throw new NotImplementedException();
        }
    }
}
