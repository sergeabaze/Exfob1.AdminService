using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob1.Communs;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Langues.Request;
using Exfob1.Models.Adminstrations.Langues.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic
{
    public class LangueBLL : ILangueBLL
    {
        private readonly ILangueService _service;
        private readonly IMapper _mapper;
        #region Constructeurs
        public LangueBLL(ILangueService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper;
        }

        #endregion

        #region Pulic methods
        public async  Task<WebApiListResponse<LangueListe>> ObtenireLangueListe()
        {
            var result = new WebApiListResponse<LangueListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _service.ObtenireLangueListe();
                if (!query.Any())
                {
                    return CommunValidators.NotFoundRequestMessage(
                         result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<IEnumerable<LangueListe>>(query);
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
            }
            return result;
        }

        public async  Task<WebApiSingleResponse<LangueReponse>> ObtenireLangueParId(int Id)
        {
            var result = new WebApiSingleResponse<LangueReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };


            try
            {
                var query = await _service.ObtenireLangueParId(Id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                        result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<LangueReponse>(query);
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }
        public async  Task<WebApiSingleResponse<LangueReponse>> CreationLangue(LangueRequest entity)
        {
            var result = new WebApiSingleResponse<LangueReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {

                var id = await _service.CreationLangue(_mapper.Map<Langue>(entity));
                result.Model = new LangueReponse { LangueID = id };
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }

        public async  Task<WebApiSingleResponse<LangueReponse>> MisejourLangue(LangueEdit entity)
        {
            var result = new WebApiSingleResponse<LangueReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
              
                await _service.MisejourLangue(_mapper.Map<Langue>(entity));
                result.Model = new LangueReponse { LangueID = entity.LangueID };
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
            }
            return result;
        }

        public async  Task<WebApiSingleResponse<LangueReponse>> SuppressionLangue(int id)
        {
            var result = new WebApiSingleResponse<LangueReponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
               
                var query = await _service.ObtenireLangueParId(id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                     result, ResourceMessage.ErrurNotFound_Suppression);
                }

                await _service.SuppressionLangue(id);

                result.Model = new LangueReponse { LangueID = id };
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
