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
	public class CompteBanqueBLL : ICompteBanqueBLL
	{
		private readonly ICompteBanqueService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public CompteBanqueBLL(ICompteBanqueService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<CompteBanqueListe>> ObtenireCompteBanqueListe()
		{
			var result = new WebApiListResponse<CompteBanqueListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCompteBanqueListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<CompteBanqueListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CompteBanqueReponse>> ObtenireCompteBanqueParId(int Id)
		{
			var result = new WebApiSingleResponse<CompteBanqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCompteBanqueParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<CompteBanqueReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CompteBanqueReponse>> CreationCompteBanque(CompteBanqueRequest entity)
		{
			var result = new WebApiSingleResponse<CompteBanqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationCompteBanque(_mapper.Map<CompteBanque>(entity));
				result.Model = new CompteBanqueReponse { CompteBanqueID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CompteBanqueReponse>> MisejourCompteBanque(CompteBanqueEdit entity)
		{
			var result = new WebApiSingleResponse<CompteBanqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourCompteBanque(_mapper.Map<CompteBanque>(entity));
				result.Model = new CompteBanqueReponse { CompteBanqueID = entity.CompteBanqueID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CompteBanqueReponse>> SuppressionCompteBanque(int id)
		{
			var result = new WebApiSingleResponse<CompteBanqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCompteBanqueParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionCompteBanque(id);
				result.Model = new CompteBanqueReponse { CompteBanqueID = id };
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
