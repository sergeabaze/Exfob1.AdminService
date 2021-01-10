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
	public class ConteneurOrigineBLL : IConteneurOrigineBLL
	{
		private readonly IConteneurOrigineService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ConteneurOrigineBLL(IConteneurOrigineService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ConteneurOrigineListe>> ObtenireConteneurOrigineListe()
		{
			var result = new WebApiListResponse<ConteneurOrigineListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireConteneurOrigineListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ConteneurOrigineListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ConteneurOrigineReponse>> ObtenireConteneurOrigineParId(int Id)
		{
			var result = new WebApiSingleResponse<ConteneurOrigineReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireConteneurOrigineParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ConteneurOrigineReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ConteneurOrigineReponse>> CreationConteneurOrigine(ConteneurOrigineRequest entity)
		{
			var result = new WebApiSingleResponse<ConteneurOrigineReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationConteneurOrigine(_mapper.Map<ConteneurOrigine>(entity));
				result.Model = new ConteneurOrigineReponse { ContenaireOrigineID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ConteneurOrigineReponse>> MisejourConteneurOrigine(ConteneurOrigineEdit entity)
		{
			var result = new WebApiSingleResponse<ConteneurOrigineReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourConteneurOrigine(_mapper.Map<ConteneurOrigine>(entity));
				result.Model = new ConteneurOrigineReponse { ContenaireOrigineID = entity.ConteneurOrigineID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ConteneurOrigineReponse>> SuppressionConteneurOrigine(int id)
		{
			var result = new WebApiSingleResponse<ConteneurOrigineReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireConteneurOrigineParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionConteneurOrigine(id);
				result.Model = new ConteneurOrigineReponse { ContenaireOrigineID = id };
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
