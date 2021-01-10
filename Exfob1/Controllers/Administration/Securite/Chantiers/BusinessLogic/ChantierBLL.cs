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
	public class ChantierBLL : IChantierBLL
	{
		private readonly IChantierService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ChantierBLL(IChantierService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ChantierListe>> ObtenireChantierListe()
		{
			var result = new WebApiListResponse<ChantierListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireChantierListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ChantierListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ChantierReponse>> ObtenireChantierParId(int Id)
		{
			var result = new WebApiSingleResponse<ChantierReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireChantierParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ChantierReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ChantierReponse>> CreationChantier(ChantierRequest entity)
		{
			var result = new WebApiSingleResponse<ChantierReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationChantier(_mapper.Map<Chantier>(entity));
				result.Model = new ChantierReponse { ChantierID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ChantierReponse>> MisejourChantier(ChantierEdit entity)
		{
			var result = new WebApiSingleResponse<ChantierReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourChantier(_mapper.Map<Chantier>(entity));
				result.Model = new ChantierReponse { ChantierID = entity.ChantierID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ChantierReponse>> SuppressionChantier(int id)
		{
			var result = new WebApiSingleResponse<ChantierReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireChantierParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionChantier(id);
				result.Model = new ChantierReponse { ChantierID = id };
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
