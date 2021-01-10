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
	public class SiteAutoriseBLL : ISiteAutoriseBLL
	{
		private readonly ISiteAutoriseService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public SiteAutoriseBLL(ISiteAutoriseService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<SiteAutoriseListe>> ObtenireSiteAutoriseListe()
		{
			var result = new WebApiListResponse<SiteAutoriseListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSiteAutoriseListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<SiteAutoriseListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SiteAutoriseReponse>> ObtenireSiteAutoriseParId(int Id)
		{
			var result = new WebApiSingleResponse<SiteAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSiteAutoriseParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<SiteAutoriseReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SiteAutoriseReponse>> CreationSiteAutorise(SiteAutoriseRequest entity)
		{
			var result = new WebApiSingleResponse<SiteAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationSiteAutorise(_mapper.Map<SiteAutorise>(entity));
				result.Model = new SiteAutoriseReponse { SiteAutoriseID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SiteAutoriseReponse>> MisejourSiteAutorise(SiteAutoriseEdit entity)
		{
			var result = new WebApiSingleResponse<SiteAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourSiteAutorise(_mapper.Map<SiteAutorise>(entity));
				result.Model = new SiteAutoriseReponse { SiteAutoriseID = entity.SiteAutoriseID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SiteAutoriseReponse>> SuppressionSiteAutorise(int id)
		{
			var result = new WebApiSingleResponse<SiteAutoriseReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSiteAutoriseParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionSiteAutorise(id);
				result.Model = new SiteAutoriseReponse { SiteAutoriseID = id };
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
