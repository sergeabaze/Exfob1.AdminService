using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
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

        public async  Task SuppressionUtilisateur(int id)
        {
            await _repository.Delete(id);
        }

        /*
        public async Task<WebApiListResponse<UtilisateurList>> ObtenireUtilisateurListe(int siteOperationId)
        {
            var result = new WebApiListResponse<UtilisateurList>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _repository.GetListe(siteOperationId);
                result.Model = _traducteur.FromEntityToModel(query);

            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurReponse>> ObtenireUtilisateurParId(int Id)
        {
            var result = new WebApiSingleResponse<UtilisateurReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };


            try
            {
                var query = await _repository.GetById(Id);
                result.Model = _traducteur.FromEntityToModel(query);

            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurRequestReponse>> CreationUtilisateur(UtilisateurCreate entity)
        {
            var result = new WebApiSingleResponse<UtilisateurRequestReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var id = await _repository.Creation(_traducteur.FromModelToEntity(entity));
                result.Model = new UtilisateurRequestReponse { UtilisateurID = id };

            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourUtilisateur(UtilisateurEdit entity)
        {
            var result = new WebApiSingleResponse<UtilisateurRequestReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var id = await _repository.Creation(_traducteur.FromModelToEntity(entity));
                result.Model = new UtilisateurRequestReponse { UtilisateurID = id };
                result.CodeMessage = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurRequestReponse>> SuppressionUtilisateur(int id)
        {
            var result = new WebApiSingleResponse<UtilisateurRequestReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                await _repository.Delete(id);

                result.Model = new UtilisateurRequestReponse { UtilisateurID = id };
                result.CodeMessage = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.CodeMessage = StatusCodes.Status400BadRequest;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        */
    }
}
