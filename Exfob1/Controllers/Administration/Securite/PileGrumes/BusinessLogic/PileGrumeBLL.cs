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
	public class PileGrumeBLL : IPileGrumeBLL
	{
		private readonly IPileGrumeService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public PileGrumeBLL(IPileGrumeService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<PileGrumeListe>> ObtenirePileGrumeListe()
		{
			var result = new WebApiListResponse<PileGrumeListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePileGrumeListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<PileGrumeListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PileGrumeReponse>> ObtenirePileGrumeParId(int Id)
		{
			var result = new WebApiSingleResponse<PileGrumeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePileGrumeParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<PileGrumeReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PileGrumeReponse>> CreationPileGrume(PileGrumeRequest entity)
		{
			var result = new WebApiSingleResponse<PileGrumeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationPileGrume(_mapper.Map<PileGrume>(entity));
				result.Model = new PileGrumeReponse { PileGrumeID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PileGrumeReponse>> MisejourPileGrume(PileGrumeEdit entity)
		{
			var result = new WebApiSingleResponse<PileGrumeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourPileGrume(_mapper.Map<PileGrume>(entity));
				result.Model = new PileGrumeReponse { PileGrumeID = entity.PileGrumeID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<PileGrumeReponse>> SuppressionPileGrume(int id)
		{
			var result = new WebApiSingleResponse<PileGrumeReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenirePileGrumeParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionPileGrume(id);
				result.Model = new PileGrumeReponse { PileGrumeID = id };
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
