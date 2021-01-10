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
	public class LoadingNavireBLL : ILoadingNavireBLL
	{
		private readonly ILoadingNavireService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public LoadingNavireBLL(ILoadingNavireService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<LoadingNavireListe>> ObtenireLoadingNavireListe()
		{
			var result = new WebApiListResponse<LoadingNavireListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLoadingNavireListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<LoadingNavireListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LoadingNavireReponse>> ObtenireLoadingNavireParId(int Id)
		{
			var result = new WebApiSingleResponse<LoadingNavireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLoadingNavireParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<LoadingNavireReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LoadingNavireReponse>> CreationLoadingNavire(LoadingNavireRequest entity)
		{
			var result = new WebApiSingleResponse<LoadingNavireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationLoadingNavire(_mapper.Map<LoadingNavire>(entity));
				result.Model = new LoadingNavireReponse { LoadingNavireID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LoadingNavireReponse>> MisejourLoadingNavire(LoadingNavireEdit entity)
		{
			var result = new WebApiSingleResponse<LoadingNavireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourLoadingNavire(_mapper.Map<LoadingNavire>(entity));
				result.Model = new LoadingNavireReponse { LoadingNavireID = entity.LoadingNavireID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LoadingNavireReponse>> SuppressionLoadingNavire(int id)
		{
			var result = new WebApiSingleResponse<LoadingNavireReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLoadingNavireParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionLoadingNavire(id);
				result.Model = new LoadingNavireReponse { LoadingNavireID = id };
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
