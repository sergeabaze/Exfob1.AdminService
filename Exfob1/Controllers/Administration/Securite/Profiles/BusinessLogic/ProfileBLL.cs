using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob1.Communs;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Profiles.Request;
using Exfob1.Models.Adminstrations.Profiles.ResPonse;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic
{
    public class ProfileBLL : IProfileBLL
    {
        private readonly IProfileService _service;
        private readonly IMapper _mapper;
        #region Constructeurs
        public ProfileBLL(IProfileService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper;
        }

        #endregion

        #region Public Methods


        public async Task<WebApiListResponse<ProfileListe>> ObtenireProfileListe()
        {
            var result = new WebApiListResponse<ProfileListe>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _service.ObtenireProfileListe();
                if (!query.Any())
                {
                    return CommunValidators.NotFoundRequestMessage(
                         result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<IEnumerable<ProfileListe>>(query);
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                      result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<ProfileResponse>> ObtenireProfileParId(int Id)
        {
            var result = new WebApiSingleResponse<ProfileResponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };


            try
            {
                var query = await _service.ObtenireProfileParId(Id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                         result, ResourceMessage.ErrurNotFound);
                }

                result.Model = _mapper.Map<ProfileResponse>(query);
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<ProfileResponse>> CreationProfile(ProfileRequest entity)
        {
            var result = new WebApiSingleResponse<ProfileResponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var id = await _service.CreationProfile(_mapper.Map<Profil>(entity));
                result.Model = new ProfileResponse { ProfilID = id };
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<ProfileResponse>> MisejourProfile(ProfileEdit entity)
        {
            var result = new WebApiSingleResponse<ProfileResponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                await _service.MisejourProfile(_mapper.Map<Profil>(entity));

                result.Model = new ProfileResponse { ProfilID = entity.ProfilID };
                result.Message = ResourceMessage.Message001;

            }
            catch (Exception ex)
            {
                result = CommunValidators.ExceptionRequestMessage(
                     result, ex.Message);
            }
            return result;
        }

        public async Task<WebApiSingleResponse<ProfileResponse>> SuppressionProfile(int id)
        {
            var result = new WebApiSingleResponse<ProfileResponse>
            {
                CodeMessage = StatusCodes.Status200OK,
                IsError = false,
            };

            try
            {
                var query = await _service.ObtenireProfileParId(id);
                if (query == null)
                {
                    return CommunValidators.NotFoundRequestMessage(
                      result, ResourceMessage.ErrurNotFound_Suppression);
                }


                await _service.SuppressionProfile(id);

                result.Model = new ProfileResponse { ProfilID = id };
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
