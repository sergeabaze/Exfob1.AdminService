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
	public class SocieteMaritimeBLL : ISocieteMaritimeBLL
	{
		private readonly ISocieteMaritimeService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public SocieteMaritimeBLL(ISocieteMaritimeService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<SocieteMaritimeListe>> ObtenireSocieteMaritimeListe()
		{
			var result = new WebApiListResponse<SocieteMaritimeListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSocieteMaritimeListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<SocieteMaritimeListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SocieteMaritimeReponse>> ObtenireSocieteMaritimeParId(int Id)
		{
			var result = new WebApiSingleResponse<SocieteMaritimeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSocieteMaritimeParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<SocieteMaritimeReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SocieteMaritimeReponse>> CreationSocieteMaritime(SocieteMaritimeRequest entity)
		{
			var result = new WebApiSingleResponse<SocieteMaritimeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationSocieteMaritime(_mapper.Map<SocieteMaritime>(entity));
				result.Model = new SocieteMaritimeReponse { SocieteMaritimeID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SocieteMaritimeReponse>> MisejourSocieteMaritime(SocieteMaritimeEdit entity)
		{
			var result = new WebApiSingleResponse<SocieteMaritimeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourSocieteMaritime(_mapper.Map<SocieteMaritime>(entity));
				result.Model = new SocieteMaritimeReponse { SocieteMaritimeID = entity.SocieteMaritimeID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SocieteMaritimeReponse>> SuppressionSocieteMaritime(int id)
		{
			var result = new WebApiSingleResponse<SocieteMaritimeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSocieteMaritimeParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionSocieteMaritime(id);
				result.Model = new SocieteMaritimeReponse { SocieteMaritimeID = id };
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
