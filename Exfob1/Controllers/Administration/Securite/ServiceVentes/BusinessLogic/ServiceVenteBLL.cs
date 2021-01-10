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
	public class ServiceVenteBLL : IServiceVenteBLL
	{
		private readonly IServiceVenteService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ServiceVenteBLL(IServiceVenteService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ServiceVenteListe>> ObtenireServiceVenteListe()
		{
			var result = new WebApiListResponse<ServiceVenteListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireServiceVenteListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ServiceVenteListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ServiceVenteReponse>> ObtenireServiceVenteParId(int Id)
		{
			var result = new WebApiSingleResponse<ServiceVenteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireServiceVenteParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ServiceVenteReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ServiceVenteReponse>> CreationServiceVente(ServiceVenteRequest entity)
		{
			var result = new WebApiSingleResponse<ServiceVenteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationServiceVente(_mapper.Map<ServiceVente>(entity));
				result.Model = new ServiceVenteReponse { ServiceVenteID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ServiceVenteReponse>> MisejourServiceVente(ServiceVenteEdit entity)
		{
			var result = new WebApiSingleResponse<ServiceVenteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourServiceVente(_mapper.Map<ServiceVente>(entity));
				result.Model = new ServiceVenteReponse { ServiceVenteID = entity.ServiceVenteID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ServiceVenteReponse>> SuppressionServiceVente(int id)
		{
			var result = new WebApiSingleResponse<ServiceVenteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireServiceVenteParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionServiceVente(id);
				result.Model = new ServiceVenteReponse { ServiceVenteID = id };
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
