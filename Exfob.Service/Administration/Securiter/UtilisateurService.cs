using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using Exfob.Service.Traducteurs.Administration.Securiter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Service.Administration.Securiter
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _repository;
        private readonly IUtilisateurTraducteur _traducteur;

        public UtilisateurService(IUtilisateurRepository repository, IUtilisateurTraducteur traducteur)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _traducteur = traducteur ?? throw new ArgumentNullException(nameof(traducteur));
        }


        public async  Task<IEnumerable<Utilisateur>> ObtenireUtilisateurListe(int siteOperationId)
        {
            return await _repository.GetListe(siteOperationId);
        }

        public async  Task<Utilisateur> ObtenireUtilisateurParId(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async  Task<int> CreationUtilisateur(Utilisateur entity)
        {
           return  await _repository.Creation(entity);
           
        }

        public async  Task MisejourUtilisateur(Utilisateur entity)
        {
            await _repository.Update(entity);
        }

        public async  Task MisejourPourActivationDuCompte(int UtilisateurID, bool EstActif, string MisejourPar)
        {
            await _repository.UpdateActivateAccount( UtilisateurID,  EstActif, MisejourPar);
        }

        public async  Task MiseJourDuMotDePasse(int UtilisateurID, string NewPassWord, string MisejourPar)
        {
          await _repository.UpdatePassWord(UtilisateurID,  NewPassWord,  MisejourPar);
        }

        public async  Task SuppressionUtilisateur(int id)
        {
            await _repository.Delete(id);
        }

        public async  Task<UtilisateurEdit> ObtenireUtilisateurEditParId(int Id, int SocieteId)
        {
            return   await _repository.GetEditById(Id, SocieteId);
           
           
        }

        public async  Task<UtilisateurLoginModel> ObtenireLoggin(string NomUtilisateur, string MotPasse)
        {
           return await _repository.GetLoggin(NomUtilisateur, MotPasse);
        }

       
    }
}
