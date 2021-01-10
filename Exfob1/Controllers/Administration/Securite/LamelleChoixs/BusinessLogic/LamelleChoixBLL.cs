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
	public class LamelleChoixBLL : ILamelleChoixBLL
	{
		private readonly ILamelleChoixService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public LamelleChoixBLL(ILamelleChoixService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<LamelleChoixListe>> ObtenireLamelleChoixListe()
		{
			var result = new WebApiListResponse<LamelleChoixListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleChoixListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<LamelleChoixListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleChoixReponse>> ObtenireLamelleChoixParId(int Id)
		{
			var result = new WebApiSingleResponse<LamelleChoixReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleChoixParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<LamelleChoixReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleChoixReponse>> CreationLamelleChoix(LamelleChoixRequest entity)
		{
			var result = new WebApiSingleResponse<LamelleChoixReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationLamelleChoix(_mapper.Map<LamelleChoix>(entity));
				result.Model = new LamelleChoixReponse { LamelleChoixID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleChoixReponse>> MisejourLamelleChoix(LamelleChoixEdit entity)
		{
			var result = new WebApiSingleResponse<LamelleChoixReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourLamelleChoix(_mapper.Map<LamelleChoix>(entity));
				result.Model = new LamelleChoixReponse { LamelleChoixID = entity.LamelleChoixID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleChoixReponse>> SuppressionLamelleChoix(int id)
		{
			var result = new WebApiSingleResponse<LamelleChoixReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleChoixParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionLamelleChoix(id);
				result.Model = new LamelleChoixReponse { LamelleChoixID = id };
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
