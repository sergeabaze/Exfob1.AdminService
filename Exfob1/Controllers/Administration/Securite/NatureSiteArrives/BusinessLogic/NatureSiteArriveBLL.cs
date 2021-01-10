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
	public class NatureSiteArriveBLL : INatureSiteArriveBLL
	{
		private readonly INatureSiteArriveService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public NatureSiteArriveBLL(INatureSiteArriveService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<NatureSiteArriveListe>> ObtenireNatureSiteArriveListe()
		{
			var result = new WebApiListResponse<NatureSiteArriveListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureSiteArriveListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<NatureSiteArriveListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureSiteArriveReponse>> ObtenireNatureSiteArriveParId(int Id)
		{
			var result = new WebApiSingleResponse<NatureSiteArriveReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureSiteArriveParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<NatureSiteArriveReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureSiteArriveReponse>> CreationNatureSiteArrive(NatureSiteArriveRequest entity)
		{
			var result = new WebApiSingleResponse<NatureSiteArriveReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationNatureSiteArrive(_mapper.Map<NatureSiteArrive>(entity));
				result.Model = new NatureSiteArriveReponse { NatureSiteArriveID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureSiteArriveReponse>> MisejourNatureSiteArrive(NatureSiteArriveEdit entity)
		{
			var result = new WebApiSingleResponse<NatureSiteArriveReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourNatureSiteArrive(_mapper.Map<NatureSiteArrive>(entity));
				result.Model = new NatureSiteArriveReponse { NatureSiteArriveID = entity.NatureSiteArriveID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureSiteArriveReponse>> SuppressionNatureSiteArrive(int id)
		{
			var result = new WebApiSingleResponse<NatureSiteArriveReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureSiteArriveParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionNatureSiteArrive(id);
				result.Model = new NatureSiteArriveReponse { NatureSiteArriveID = id };
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
