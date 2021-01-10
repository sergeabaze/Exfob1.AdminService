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
	public class DensiteBoisBLL : IDensiteBoisBLL
	{
		private readonly IDensiteBoisService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public DensiteBoisBLL(IDensiteBoisService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<DensiteBoisListe>> ObtenireDensiteBoisListe()
		{
			var result = new WebApiListResponse<DensiteBoisListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDensiteBoisListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<DensiteBoisListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DensiteBoisReponse>> ObtenireDensiteBoisParId(int Id)
		{
			var result = new WebApiSingleResponse<DensiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDensiteBoisParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<DensiteBoisReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DensiteBoisReponse>> CreationDensiteBois(DensiteBoisRequest entity)
		{
			var result = new WebApiSingleResponse<DensiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationDensiteBois(_mapper.Map<DensiteBois>(entity));
				result.Model = new DensiteBoisReponse { DensiteBoisID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DensiteBoisReponse>> MisejourDensiteBois(DensiteBoisEdit entity)
		{
			var result = new WebApiSingleResponse<DensiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourDensiteBois(_mapper.Map<DensiteBois>(entity));
				result.Model = new DensiteBoisReponse { DensiteBoisID = entity.DensiteBoisID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<DensiteBoisReponse>> SuppressionDensiteBois(int id)
		{
			var result = new WebApiSingleResponse<DensiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireDensiteBoisParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionDensiteBois(id);
				result.Model = new DensiteBoisReponse { DensiteBoisID = id };
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
