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
	public class TypeoperationControleBLL : ITypeoperationControleBLL
	{
		private readonly ITypeoperationControleService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public TypeoperationControleBLL(ITypeoperationControleService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<TypeoperationControleListe>> ObtenireTypeoperationControleListe()
		{
			var result = new WebApiListResponse<TypeoperationControleListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeoperationControleListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<TypeoperationControleListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeoperationControleReponse>> ObtenireTypeoperationControleParId(int Id)
		{
			var result = new WebApiSingleResponse<TypeoperationControleReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeoperationControleParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<TypeoperationControleReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeoperationControleReponse>> CreationTypeoperationControle(TypeoperationControleRequest entity)
		{
			var result = new WebApiSingleResponse<TypeoperationControleReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationTypeoperationControle(_mapper.Map<TypeoperationControle>(entity));
				result.Model = new TypeoperationControleReponse { TypeOperationControleID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeoperationControleReponse>> MisejourTypeoperationControle(TypeoperationControleEdit entity)
		{
			var result = new WebApiSingleResponse<TypeoperationControleReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourTypeoperationControle(_mapper.Map<TypeoperationControle>(entity));
				result.Model = new TypeoperationControleReponse { TypeOperationControleID = entity.TypeoperationControleID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeoperationControleReponse>> SuppressionTypeoperationControle(int id)
		{
			var result = new WebApiSingleResponse<TypeoperationControleReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeoperationControleParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionTypeoperationControle(id);
				result.Model = new TypeoperationControleReponse { TypeOperationControleID = id };
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
