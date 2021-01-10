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
	public class DroitAutoriseBLL : IDroitAutoriseBLL
	{
		private readonly IDroitAutoriseService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public DroitAutoriseBLL(IDroitAutoriseService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<DroitAutoriseListe>> ObtenireDroitAutoriseListe()
		{
			var result = new WebApiListResponse<DroitAutoriseListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDroitAutoriseListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<DroitAutoriseListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DroitAutoriseReponse>> ObtenireDroitAutoriseParId(int Id)
		{
			var result = new WebApiSingleResponse<DroitAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDroitAutoriseParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<DroitAutoriseReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DroitAutoriseReponse>> CreationDroitAutorise(DroitAutoriseRequest entity)
		{
			var result = new WebApiSingleResponse<DroitAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationDroitAutorise(_mapper.Map<DroitAutorise>(entity));
				result.Model = new DroitAutoriseReponse { DroitAutoriseID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DroitAutoriseReponse>> MisejourDroitAutorise(DroitAutoriseEdit entity)
		{
			var result = new WebApiSingleResponse<DroitAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourDroitAutorise(_mapper.Map<DroitAutorise>(entity));
				result.Model = new DroitAutoriseReponse { DroitAutoriseID = entity.DroitAutoriseID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DroitAutoriseReponse>> SuppressionDroitAutorise(int id)
		{
			var result = new WebApiSingleResponse<DroitAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDroitAutoriseParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionDroitAutorise(id);
				result.Model = new DroitAutoriseReponse { DroitAutoriseID = id };
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
