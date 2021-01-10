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
	public class AffecterEquipeBLL : IAffecterEquipeBLL
	{
		private readonly IAffecterEquipeService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public AffecterEquipeBLL(IAffecterEquipeService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<AffecterEquipeListe>> ObtenireAffecterEquipeListe()
		{
			var result = new WebApiListResponse<AffecterEquipeListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireAffecterEquipeListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<AffecterEquipeListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<AffecterEquipeReponse>> ObtenireAffecterEquipeParId(int Id)
		{
			var result = new WebApiSingleResponse<AffecterEquipeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireAffecterEquipeParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<AffecterEquipeReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<AffecterEquipeReponse>> CreationAffecterEquipe(AffecterEquipeRequest entity)
		{
			var result = new WebApiSingleResponse<AffecterEquipeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationAffecterEquipe(_mapper.Map<AffecterEquipe>(entity));
				result.Model = new AffecterEquipeReponse { AffecterEquipeID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<AffecterEquipeReponse>> MisejourAffecterEquipe(AffecterEquipeEdit entity)
		{
			var result = new WebApiSingleResponse<AffecterEquipeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourAffecterEquipe(_mapper.Map<AffecterEquipe>(entity));
				result.Model = new AffecterEquipeReponse { AffecterEquipeID = entity.AffecterEquipeID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<AffecterEquipeReponse>> SuppressionAffecterEquipe(int id)
		{
			var result = new WebApiSingleResponse<AffecterEquipeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireAffecterEquipeParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionAffecterEquipe(id);
				result.Model = new AffecterEquipeReponse { AffecterEquipeID = id };
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
