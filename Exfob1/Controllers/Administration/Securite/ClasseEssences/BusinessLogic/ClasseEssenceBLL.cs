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
	public class ClasseEssenceBLL : IClasseEssenceBLL
	{
		private readonly IClasseEssenceService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ClasseEssenceBLL(IClasseEssenceService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ClasseEssenceListe>> ObtenireClasseEssenceListe()
		{
			var result = new WebApiListResponse<ClasseEssenceListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClasseEssenceListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ClasseEssenceListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClasseEssenceReponse>> ObtenireClasseEssenceParId(int Id)
		{
			var result = new WebApiSingleResponse<ClasseEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClasseEssenceParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ClasseEssenceReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClasseEssenceReponse>> CreationClasseEssence(ClasseEssenceRequest entity)
		{
			var result = new WebApiSingleResponse<ClasseEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationClasseEssence(_mapper.Map<ClasseEssence>(entity));
				result.Model = new ClasseEssenceReponse { ClasseEssenceID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClasseEssenceReponse>> MisejourClasseEssence(ClasseEssenceEdit entity)
		{
			var result = new WebApiSingleResponse<ClasseEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourClasseEssence(_mapper.Map<ClasseEssence>(entity));
				result.Model = new ClasseEssenceReponse { ClasseEssenceID = entity.ClasseEssenceID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ClasseEssenceReponse>> SuppressionClasseEssence(int id)
		{
			var result = new WebApiSingleResponse<ClasseEssenceReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireClasseEssenceParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionClasseEssence(id);
				result.Model = new ClasseEssenceReponse { ClasseEssenceID = id };
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
