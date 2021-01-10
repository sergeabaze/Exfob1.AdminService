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
	public class PortEmbarquementBLL : IPortEmbarquementBLL
	{
		private readonly IPortEmbarquementService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public PortEmbarquementBLL(IPortEmbarquementService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<PortEmbarquementListe>> ObtenirePortEmbarquementListe()
		{
			var result = new WebApiListResponse<PortEmbarquementListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePortEmbarquementListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<PortEmbarquementListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PortEmbarquementReponse>> ObtenirePortEmbarquementParId(int Id)
		{
			var result = new WebApiSingleResponse<PortEmbarquementReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePortEmbarquementParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<PortEmbarquementReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PortEmbarquementReponse>> CreationPortEmbarquement(PortEmbarquementRequest entity)
		{
			var result = new WebApiSingleResponse<PortEmbarquementReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationPortEmbarquement(_mapper.Map<PortEmbarquement>(entity));
				result.Model = new PortEmbarquementReponse { PortEmbraquementID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PortEmbarquementReponse>> MisejourPortEmbarquement(PortEmbarquementEdit entity)
		{
			var result = new WebApiSingleResponse<PortEmbarquementReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourPortEmbarquement(_mapper.Map<PortEmbarquement>(entity));
				result.Model = new PortEmbarquementReponse { PortEmbraquementID = entity.PortEmbarquementID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PortEmbarquementReponse>> SuppressionPortEmbarquement(int id)
		{
			var result = new WebApiSingleResponse<PortEmbarquementReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePortEmbarquementParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionPortEmbarquement(id);
				result.Model = new PortEmbarquementReponse { PortEmbraquementID = id };
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
