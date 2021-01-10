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
	public class ModeEnvoieBLL : IModeEnvoieBLL
	{
		private readonly IModeEnvoieService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ModeEnvoieBLL(IModeEnvoieService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ModeEnvoieListe>> ObtenireModeEnvoieListe()
		{
			var result = new WebApiListResponse<ModeEnvoieListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireModeEnvoieListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ModeEnvoieListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ModeEnvoieReponse>> ObtenireModeEnvoieParId(int Id)
		{
			var result = new WebApiSingleResponse<ModeEnvoieReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireModeEnvoieParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ModeEnvoieReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ModeEnvoieReponse>> CreationModeEnvoie(ModeEnvoieRequest entity)
		{
			var result = new WebApiSingleResponse<ModeEnvoieReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationModeEnvoie(_mapper.Map<ModeEnvoie>(entity));
				result.Model = new ModeEnvoieReponse { ModeEnvoieID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ModeEnvoieReponse>> MisejourModeEnvoie(ModeEnvoieEdit entity)
		{
			var result = new WebApiSingleResponse<ModeEnvoieReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourModeEnvoie(_mapper.Map<ModeEnvoie>(entity));
				result.Model = new ModeEnvoieReponse { ModeEnvoieID = entity.ModeEnvoieID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ModeEnvoieReponse>> SuppressionModeEnvoie(int id)
		{
			var result = new WebApiSingleResponse<ModeEnvoieReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireModeEnvoieParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionModeEnvoie(id);
				result.Model = new ModeEnvoieReponse { ModeEnvoieID = id };
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
