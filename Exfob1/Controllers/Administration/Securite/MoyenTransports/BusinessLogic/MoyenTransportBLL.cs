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
	public class MoyenTransportBLL : IMoyenTransportBLL
	{
		private readonly IMoyenTransportService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public MoyenTransportBLL(IMoyenTransportService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<MoyenTransportListe>> ObtenireMoyenTransportListe()
		{
			var result = new WebApiListResponse<MoyenTransportListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireMoyenTransportListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<MoyenTransportListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<MoyenTransportReponse>> ObtenireMoyenTransportParId(int Id)
		{
			var result = new WebApiSingleResponse<MoyenTransportReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireMoyenTransportParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<MoyenTransportReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<MoyenTransportReponse>> CreationMoyenTransport(MoyenTransportRequest entity)
		{
			var result = new WebApiSingleResponse<MoyenTransportReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationMoyenTransport(_mapper.Map<MoyenTransport>(entity));
				result.Model = new MoyenTransportReponse { MoyenTransportID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<MoyenTransportReponse>> MisejourMoyenTransport(MoyenTransportEdit entity)
		{
			var result = new WebApiSingleResponse<MoyenTransportReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourMoyenTransport(_mapper.Map<MoyenTransport>(entity));
				result.Model = new MoyenTransportReponse { MoyenTransportID = entity.MoyenTransportID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<MoyenTransportReponse>> SuppressionMoyenTransport(int id)
		{
			var result = new WebApiSingleResponse<MoyenTransportReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireMoyenTransportParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionMoyenTransport(id);
				result.Model = new MoyenTransportReponse { MoyenTransportID = id };
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
