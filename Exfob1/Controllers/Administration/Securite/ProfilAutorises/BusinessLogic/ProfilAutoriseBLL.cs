using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Exfob1.Communs;
using Exfob1.Models;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
using Exfob.Core.Services.Administration;
namespace Exfob1.Controllers.Administration
{
	public class ProfilAutoriseBLL : IProfilAutoriseBLL
	{
		private readonly IProfilAutoriseService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ProfilAutoriseBLL(IProfilAutoriseService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ProfilAutoriseListe>> ObtenireProfilAutoriseListe()
		{
			var result = new WebApiListResponse<ProfilAutoriseListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireProfilAutoriseListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ProfilAutoriseListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ProfilAutoriseReponse>> ObtenireProfilAutoriseParId(int Id)
		{
			var result = new WebApiSingleResponse<ProfilAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireProfilAutoriseParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ProfilAutoriseReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ProfilAutoriseReponse>> CreationProfilAutorise(ProfilAutoriseRequest entity)
		{
			var result = new WebApiSingleResponse<ProfilAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationProfilAutorise(_mapper.Map<ProfilAutorise>(entity));
				result.Model = new ProfilAutoriseReponse { ProfilAutoriseID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ProfilAutoriseReponse>> MisejourProfilAutorise(ProfilAutoriseEdit entity)
		{
			var result = new WebApiSingleResponse<ProfilAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourProfilAutorise(_mapper.Map<ProfilAutorise>(entity));
				result.Model = new ProfilAutoriseReponse { ProfilAutoriseID = entity.ProfilAutoriseID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ProfilAutoriseReponse>> SuppressionProfilAutorise(int id)
		{
			var result = new WebApiSingleResponse<ProfilAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireProfilAutoriseParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionProfilAutorise(id);
				result.Model = new ProfilAutoriseReponse { ProfilAutoriseID = id };
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
