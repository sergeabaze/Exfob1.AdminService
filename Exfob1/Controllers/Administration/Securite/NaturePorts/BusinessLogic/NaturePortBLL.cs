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
	public class NaturePortBLL : INaturePortBLL
	{
		private readonly INaturePortService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public NaturePortBLL(INaturePortService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<NaturePortListe>> ObtenireNaturePortListe()
		{
			var result = new WebApiListResponse<NaturePortListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNaturePortListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<NaturePortListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NaturePortReponse>> ObtenireNaturePortParId(int Id)
		{
			var result = new WebApiSingleResponse<NaturePortReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNaturePortParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<NaturePortReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NaturePortReponse>> CreationNaturePort(NaturePortRequest entity)
		{
			var result = new WebApiSingleResponse<NaturePortReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationNaturePort(_mapper.Map<NaturePort>(entity));
				result.Model = new NaturePortReponse { NaturePortID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NaturePortReponse>> MisejourNaturePort(NaturePortEdit entity)
		{
			var result = new WebApiSingleResponse<NaturePortReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourNaturePort(_mapper.Map<NaturePort>(entity));
				result.Model = new NaturePortReponse { NaturePortID = entity.NaturePortID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NaturePortReponse>> SuppressionNaturePort(int id)
		{
			var result = new WebApiSingleResponse<NaturePortReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNaturePortParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionNaturePort(id);
				result.Model = new NaturePortReponse { NaturePortID = id };
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
