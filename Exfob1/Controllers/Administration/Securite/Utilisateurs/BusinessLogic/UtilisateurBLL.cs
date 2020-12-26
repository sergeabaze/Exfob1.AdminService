using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob1.Communs;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Utilisateurs.BusinessLogic
{
    public class UtilisateurBLL : IUtilisateurBLL
    {
        private readonly IUtilisateurService _service;
        private readonly IMapper _mapper;
        #region Constructeurs
        public UtilisateurBLL(IUtilisateurService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper;
        }

        #endregion

        #region Methodes publics

        public async Task<WebApiListResponse<UtilisateurList>> ObtenireUtilisateurListe(int siteOperationId)
        {
            var result = new WebApiListResponse<UtilisateurList>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _service.ObtenireUtilisateurListe(siteOperationId);
                if (!query.Any())
                {
                  
                    return CommunValidators.NotFoundRequestMessage(
                        result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<IEnumerable<UtilisateurList>>(query);
                result.Message = ResourceMessage.Message001;
            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
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
                var query = await _service.ObtenireUtilisateurParId(Id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                        result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<UtilisateurReponse>(query);
                result.Message = ResourceMessage.Message001;
            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurRequestReponse>> CreationUtilisateur(UtilisateurCreate model, int siteOperationid)
        {
            var result = new WebApiSingleResponse<UtilisateurRequestReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                if (siteOperationid <= 0)
                {
                    return CommunValidators.BadRequestMessage(
                         result, string.Format(ResourceMessage.Erreur1002, nameof(siteOperationid)));
                }

                var entity = _mapper.Map<Utilisateur>(model);
                entity.SiteOperationID = siteOperationid;
                entity.MotPasseHash = entity.SelMotdePasse;
                var id = await _service.CreationUtilisateur(_mapper.Map<Utilisateur>(entity));

                result.Model = new UtilisateurRequestReponse { UtilisateurID = id };
                result.Message = ResourceMessage.Message001;
            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<UtilisateurRequestReponse>> MisejourUtilisateur(
            UtilisateurEdit model,
            int siteOperationid,
            int utilisateurid)
        {
            var result = new WebApiSingleResponse<UtilisateurRequestReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                if (siteOperationid <= 0)
                {
                    return CommunValidators.BadRequestMessage(
                        result, string.Format(ResourceMessage.Erreur1002, nameof(siteOperationid)));
                }

                if (utilisateurid <= 0)
                {
                    return CommunValidators.BadRequestMessage(
                        result, string.Format(ResourceMessage.Erreur1002, nameof(utilisateurid)));
                  
                }

                var entity = _mapper.Map<Utilisateur>(model);
                entity.SiteOperationID = siteOperationid;
                entity.UtilisateurID = utilisateurid;

                await _service.MisejourUtilisateur(entity);
                result.Model = new UtilisateurRequestReponse { UtilisateurID = entity.UtilisateurID };
                result.Message = ResourceMessage.Message001;
            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
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
               

                var query = await _service.ObtenireUtilisateurParId(id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                      result, ResourceMessage.ErrurNotFound_Suppression);
                }
                await _service.SuppressionUtilisateur(id);

                result.Model = new UtilisateurRequestReponse { UtilisateurID = id };
                result.Message = ResourceMessage.Message001;
            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
            }
            return result;
        }

        #endregion
    }
}
