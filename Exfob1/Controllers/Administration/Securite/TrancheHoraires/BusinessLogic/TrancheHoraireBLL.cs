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
	public class TrancheHoraireBLL : ITrancheHoraireBLL
	{
		private readonly ITrancheHoraireService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public TrancheHoraireBLL(ITrancheHoraireService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<TrancheHoraireListe>> ObtenireTrancheHoraireListe()
		{
			var result = new WebApiListResponse<TrancheHoraireListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTrancheHoraireListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<TrancheHoraireListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TrancheHoraireReponse>> ObtenireTrancheHoraireParId(int Id)
		{
			var result = new WebApiSingleResponse<TrancheHoraireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTrancheHoraireParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<TrancheHoraireReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TrancheHoraireReponse>> CreationTrancheHoraire(TrancheHoraireRequest entity)
		{
			var result = new WebApiSingleResponse<TrancheHoraireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationTrancheHoraire(_mapper.Map<TrancheHoraire>(entity));
				result.Model = new TrancheHoraireReponse { TrancheHoraireID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TrancheHoraireReponse>> MisejourTrancheHoraire(TrancheHoraireEdit entity)
		{
			var result = new WebApiSingleResponse<TrancheHoraireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourTrancheHoraire(_mapper.Map<TrancheHoraire>(entity));
				result.Model = new TrancheHoraireReponse { TrancheHoraireID = entity.TrancheHoraireID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TrancheHoraireReponse>> SuppressionTrancheHoraire(int id)
		{
			var result = new WebApiSingleResponse<TrancheHoraireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTrancheHoraireParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionTrancheHoraire(id);
				result.Model = new TrancheHoraireReponse { TrancheHoraireID = id };
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
