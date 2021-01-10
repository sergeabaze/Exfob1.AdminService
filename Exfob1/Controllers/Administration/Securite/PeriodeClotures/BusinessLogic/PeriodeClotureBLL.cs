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
	public class PeriodeClotureBLL : IPeriodeClotureBLL
	{
		private readonly IPeriodeClotureService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public PeriodeClotureBLL(IPeriodeClotureService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<PeriodeClotureListe>> ObtenirePeriodeClotureListe()
		{
			var result = new WebApiListResponse<PeriodeClotureListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePeriodeClotureListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<PeriodeClotureListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PeriodeClotureReponse>> ObtenirePeriodeClotureParId(int Id)
		{
			var result = new WebApiSingleResponse<PeriodeClotureReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePeriodeClotureParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<PeriodeClotureReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PeriodeClotureReponse>> CreationPeriodeCloture(PeriodeClotureRequest entity)
		{
			var result = new WebApiSingleResponse<PeriodeClotureReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationPeriodeCloture(_mapper.Map<PeriodeCloture>(entity));
				result.Model = new PeriodeClotureReponse { PeriodeID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PeriodeClotureReponse>> MisejourPeriodeCloture(PeriodeClotureEdit entity)
		{
			var result = new WebApiSingleResponse<PeriodeClotureReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourPeriodeCloture(_mapper.Map<PeriodeCloture>(entity));
				result.Model = new PeriodeClotureReponse { PeriodeID = entity.PeriodeID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PeriodeClotureReponse>> SuppressionPeriodeCloture(int id)
		{
			var result = new WebApiSingleResponse<PeriodeClotureReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePeriodeClotureParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionPeriodeCloture(id);
				result.Model = new PeriodeClotureReponse { PeriodeID = id };
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
