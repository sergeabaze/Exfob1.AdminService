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
	public class ClientConsignataireBLL : IClientConsignataireBLL
	{
		private readonly IClientConsignataireService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ClientConsignataireBLL(IClientConsignataireService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ClientConsignataireListe>> ObtenireClientConsignataireListe()
		{
			var result = new WebApiListResponse<ClientConsignataireListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClientConsignataireListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ClientConsignataireListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClientConsignataireReponse>> ObtenireClientConsignataireParId(int Id)
		{
			var result = new WebApiSingleResponse<ClientConsignataireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClientConsignataireParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ClientConsignataireReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClientConsignataireReponse>> CreationClientConsignataire(ClientConsignataireRequest entity)
		{
			var result = new WebApiSingleResponse<ClientConsignataireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationClientConsignataire(_mapper.Map<ClientConsignataire>(entity));
				result.Model = new ClientConsignataireReponse { ClientConsignataireID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClientConsignataireReponse>> MisejourClientConsignataire(ClientConsignataireEdit entity)
		{
			var result = new WebApiSingleResponse<ClientConsignataireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourClientConsignataire(_mapper.Map<ClientConsignataire>(entity));
				result.Model = new ClientConsignataireReponse { ClientConsignataireID = entity.ClientConsignataireID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClientConsignataireReponse>> SuppressionClientConsignataire(int id)
		{
			var result = new WebApiSingleResponse<ClientConsignataireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClientConsignataireParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionClientConsignataire(id);
				result.Model = new ClientConsignataireReponse { ClientConsignataireID = id };
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
