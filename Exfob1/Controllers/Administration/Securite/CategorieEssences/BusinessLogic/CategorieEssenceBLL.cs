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
	public class CategorieEssenceBLL : ICategorieEssenceBLL
	{
		private readonly ICategorieEssenceService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public CategorieEssenceBLL(ICategorieEssenceService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<CategorieEssenceListe>> ObtenireCategorieEssenceListe()
		{
			var result = new WebApiListResponse<CategorieEssenceListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCategorieEssenceListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<CategorieEssenceListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CategorieEssenceReponse>> ObtenireCategorieEssenceParId(int Id)
		{
			var result = new WebApiSingleResponse<CategorieEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCategorieEssenceParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<CategorieEssenceReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CategorieEssenceReponse>> CreationCategorieEssence(CategorieEssenceRequest entity)
		{
			var result = new WebApiSingleResponse<CategorieEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationCategorieEssence(_mapper.Map<CategorieEssence>(entity));
				result.Model = new CategorieEssenceReponse { CategorieEssenceID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CategorieEssenceReponse>> MisejourCategorieEssence(CategorieEssenceEdit entity)
		{
			var result = new WebApiSingleResponse<CategorieEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourCategorieEssence(_mapper.Map<CategorieEssence>(entity));
				result.Model = new CategorieEssenceReponse { CategorieEssenceID = entity.CategorieEssenceID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CategorieEssenceReponse>> SuppressionCategorieEssence(int id)
		{
			var result = new WebApiSingleResponse<CategorieEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCategorieEssenceParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionCategorieEssence(id);
				result.Model = new CategorieEssenceReponse { CategorieEssenceID = id };
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
