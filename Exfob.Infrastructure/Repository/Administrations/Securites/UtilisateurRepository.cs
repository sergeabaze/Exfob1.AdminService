using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Models.Administration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Repository.Administrations.Securites
{
    public class UtilisateurRepository : GenericDapperRepository<Utilisateur>, IUtilisateurRepository
    {
        private IDbConnection _connection;

        #region Constructor
        public UtilisateurRepository(DbConnection context)
           : base(context)
        {
            _connection = context;
        }
        #endregion

        #region Public Methods

        public async Task<Utilisateur> GetById(int Id)
        {
            return await this.GetById(Id);
        }

        public async Task<IEnumerable<Utilisateur>> GetListe(int siteOperationid)
        {
            object parameters = new { SiteOperationID = siteOperationid };
            string query = "SELECT * FROM [Utilisateur] WHERE SiteOperationID=@SiteOperationID";
            return await this.GetDataAsync(query, parameters);
        }

        public async Task<int> Creation(Utilisateur entity)
        {
            entity.DateCreation = DateTime.Now;
            string insQuery = $@"INSERT INTO [Utilisateur]
      ([SiteOperationID]
       ,[ProfilID]
       , [Nom]
       , [LoginUtilisateur]
       , [MotPasseHash]
       , [SelMotdePasse]
       , [Email]
       , [Matricule]
       , [Fonction]
       , [EstActif]
        ,[LangueID]
        ,[DateCreation]
        ,[CreerPar]) 
        VALUES(
      @{nameof(Utilisateur.SiteOperationID)}
      ,@{nameof(Utilisateur.ProfilID)}
      ,@{nameof(Utilisateur.Nom)}
      ,@{nameof(Utilisateur.LoginUtilisateur)}
      ,@{nameof(Utilisateur.MotPasseHash)}
      ,@{nameof(Utilisateur.SelMotdePasse)}
      ,@{nameof(Utilisateur.Email)}
      ,@{nameof(Utilisateur.Matricule)}
      ,@{nameof(Utilisateur.Fonction)}
      ,@{nameof(Utilisateur.EstActif)}
	  ,@{nameof(Utilisateur.LangueID)}
	  ,@{nameof(Utilisateur.DateCreation)}
	  ,@{nameof(Utilisateur.CreerPar)})";

            object inParameters = new
            {
                entity.SiteOperationID,
                entity.ProfilID,
                entity.Nom,
                entity.LoginUtilisateur,
                entity.MotPasseHash,
                entity.SelMotdePasse,
                entity.Email,
                entity.Matricule,
                entity.Fonction,
                entity.EstActif,
                entity.LangueID,
                entity.DateCreation,
                entity.CreerPar
            };
            var id = await this.AddScalarAsync(insQuery, inParameters);
            return id;
        }


        public async Task Update(Utilisateur entity)
        {
            entity.DateMisejour = DateTime.Now;
            string insQuery = $@" UPDATE [Utilisateur] SET
     [SiteOperationID] = @{nameof(Utilisateur.SiteOperationID)},
     [ProfilID] =@{nameof(Utilisateur.ProfilID)},
     [Nom] =@{nameof(Utilisateur.Nom)},
     [LoginUtilisateur] =@{nameof(Utilisateur.LoginUtilisateur)},
     [Email] =@{nameof(Utilisateur.Email)},
     [Matricule] = @{nameof(Utilisateur.Matricule)},
     [Fonction] = @{nameof(Utilisateur.Fonction)},
     [EstActif] = @{nameof(Utilisateur.EstActif)},
	 [LangueID] = @{nameof(Utilisateur.LangueID)},
	 [DateMisejour] = @{nameof(Utilisateur.DateMisejour)},
	 [MiseJourPar] = @{nameof(Utilisateur.MiseJourPar)}
     WHERE UtilisateurID=@{nameof(Utilisateur.UtilisateurID)}
      ";

            object inParameters = new
            {
                entity.UtilisateurID,
                entity.SiteOperationID,
                entity.ProfilID,
                entity.Nom,
                entity.LoginUtilisateur,
                entity.Email,
                entity.Matricule,
                entity.Fonction,
                entity.EstActif,
                entity.LangueID,
                entity.DateMisejour,
                entity.MiseJourPar
            };
            await this.UpdateWithScriptAsync(insQuery, inParameters);

        }

        public async Task Delete(int id)
        {
            object inParameters = new { UtilisateurID = id };
            await this.RemoveAsync(inParameters);
        }
        #endregion

    }
}
