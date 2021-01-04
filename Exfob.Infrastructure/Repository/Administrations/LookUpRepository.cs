using Dapper;
using Exfob.Core.Interfaces.Administrations;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Repository.Administrations
{
    public class LookUpRepository : GenericDapperRepository<LookUpModel>, ILookUpRepository
    {
        private IDbConnection _connection;
        public LookUpRepository(DbConnection context)
           : base(context)
        {
            _connection = context;
        }
        public async  Task<IEnumerable<Acconier>> GetAconierListe(int SiteOperationID)
        {
            string query = "SELECT * FROM Acconier WHERE SiteOperationID = @SiteOperationID";
            var result = await  _connection.QueryAsync<Acconier>(query, new { SiteOperationID });
           return result;
        }

        public async  Task<IEnumerable<DroitsForListe>> GetDroitListe(int ProfileID)
        {
            string query = @"Select Droit.*, md.Libelle as Module from Droit inner join Module md
  On md.ModuleID = Droit.ModuleID
  where ProfilID =@ProfileID";
            var result = await _connection.QueryAsync<DroitsForListe>(query, new { ProfileID });
            return result;
        }

        public async  Task<IEnumerable<Langue>> GetLangueListe()
        {
            string query = "SELECT * FROM Langue;";
            var result = await _connection.QueryAsync<Langue>(query);
            return result;
        }

        public async  Task<IEnumerable<Profil>> GetProfileListe()
        {
            string query = "SELECT * FROM Profil;";
            var result = await _connection.QueryAsync<Profil>(query);
            return result;
        }

        public async  Task<IEnumerable<SiteAutoriseForListe>> GetSiteAutoriseListe(int UtilisateurID)
        {
            string queries = @"SELECT sa.[SiteAutoriseID]
        ,sa.[ProfilAutoriseID]
        ,so.Libelle  as SiteOperation
	   , pa.Libelle as ProfilAutorise
FROM SiteAutorise sa inner join SiteOperation so
  on so.SiteOperationID = sa.SiteOperationID inner join ProfilAutorise pa
  On pa.ProfilAutoriseID = sa.ProfilAutoriseID
  WHERE sa.UtilisateurID = @UtilisateurID;
 select DroitAutorise.*, md.Libelle as ModuleLibelle from DroitAutorise inner join Module md
  on md.ModuleID = DroitAutorise.ModuleID;
"
;
            var param = new DynamicParameters();
            param.Add("@UtilisateurID", UtilisateurID);
            var dataset = await this.GetAllMultiAsync(queries, param);

            var result = dataset.Read<SiteAutoriseForListe>();
            var _droitsAuths = dataset.Read<DroitAutoriseForListe>();
            if (result.Any())
            {
              foreach(var item in result)
                {
                    var droits = _droitsAuths.Where(x => x.ProfilAutoriseID == item.ProfilAutoriseID);

                    if (droits.Any())
                    {
                        item.Droits = droits;
                    }
                }
            }
            return result;
        }

        public async  Task<IEnumerable<SiteOperationForListe>> GetSiteOperationListe()
        {
            string query = "SELECT SiteOperationID, Code,Libelle FROM SiteOperation;";
            var result = await _connection.QueryAsync<SiteOperationForListe>(query);
            return result;
            
        }

        public async  Task<IEnumerable<SocieteForListe>> GetSocieteListe(int SiegeID = 0)
        {
            string query = "SELECT SocieteID, Code,Libelle,EstPeriodeCloture FROM Societe;";
            var result = await _connection.QueryAsync<SocieteForListe>(query);
            return result;
        }

        public async  Task<IEnumerable<SouTraitanceForListe>> GetSousTraitanceListe(int SiteOperationID)
        {
            string query = "SELECT SousTraitanceID,Intitule,SigleTrait FROM SousTraitance WHERE SiteOperationID = @SiteOperationID";
            var result = await _connection.QueryAsync<SouTraitanceForListe>(query, new { SiteOperationID });
            return result;
        }

        public async  Task<IEnumerable<TypeMateriel>> GetTypeMaterielListe()
        {
            string query = "SELECT * FROM TypeMateriel;";
            var result = await _connection.QueryAsync<TypeMateriel>(query);
            return result;
        }
    }
}
