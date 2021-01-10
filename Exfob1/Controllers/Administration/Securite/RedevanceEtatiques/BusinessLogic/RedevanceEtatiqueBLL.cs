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
	public class RedevanceEtatiqueBLL : IRedevanceEtatiqueBLL
	{
		private readonly IRedevanceEtatiqueService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public RedevanceEtatiqueBLL(IRedevanceEtatiqueService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<RedevanceEtatiqueListe>> ObtenireRedevanceEtatiqueListe()
		{
			var result = new WebApiListResponse<RedevanceEtatiqueListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireRedevanceEtatiqueListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<RedevanceEtatiqueListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> ObtenireRedevanceEtatiqueParId(int Id)
		{
			var result = new WebApiSingleResponse<RedevanceEtatiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireRedevanceEtatiqueParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<RedevanceEtatiqueReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> CreationRedevanceEtatique(RedevanceEtatiqueRequest entity)
		{
			var result = new WebApiSingleResponse<RedevanceEtatiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationRedevanceEtatique(_mapper.Map<RedevanceEtatique>(entity));
				result.Model = new RedevanceEtatiqueReponse { RedevanceEtatiqueID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> MisejourRedevanceEtatique(RedevanceEtatiqueEdit entity)
		{
			var result = new WebApiSingleResponse<RedevanceEtatiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourRedevanceEtatique(_mapper.Map<RedevanceEtatique>(entity));
				result.Model = new RedevanceEtatiqueReponse { RedevanceEtatiqueID = entity.RedevanceEtatiqueID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> SuppressionRedevanceEtatique(int id)
		{
			var result = new WebApiSingleResponse<RedevanceEtatiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireRedevanceEtatiqueParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionRedevanceEtatique(id);
				result.Model = new RedevanceEtatiqueReponse { RedevanceEtatiqueID = id };
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
