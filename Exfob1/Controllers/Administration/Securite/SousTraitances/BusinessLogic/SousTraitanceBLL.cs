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
	public class SousTraitanceBLL : ISousTraitanceBLL
	{
		private readonly ISousTraitanceService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public SousTraitanceBLL(ISousTraitanceService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<SousTraitanceListe>> ObtenireSousTraitanceListe()
		{
			var result = new WebApiListResponse<SousTraitanceListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSousTraitanceListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<SousTraitanceListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SousTraitanceReponse>> ObtenireSousTraitanceParId(int Id)
		{
			var result = new WebApiSingleResponse<SousTraitanceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSousTraitanceParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<SousTraitanceReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SousTraitanceReponse>> CreationSousTraitance(SousTraitanceRequest entity)
		{
			var result = new WebApiSingleResponse<SousTraitanceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationSousTraitance(_mapper.Map<SousTraitance>(entity));
				result.Model = new SousTraitanceReponse { SousTraitanceID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SousTraitanceReponse>> MisejourSousTraitance(SousTraitanceEdit entity)
		{
			var result = new WebApiSingleResponse<SousTraitanceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourSousTraitance(_mapper.Map<SousTraitance>(entity));
				result.Model = new SousTraitanceReponse { SousTraitanceID = entity.SousTraitanceID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SousTraitanceReponse>> SuppressionSousTraitance(int id)
		{
			var result = new WebApiSingleResponse<SousTraitanceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSousTraitanceParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionSousTraitance(id);
				result.Model = new SousTraitanceReponse { SousTraitanceID = id };
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
