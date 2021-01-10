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
	public class ContratFournisseurBLL : IContratFournisseurBLL
	{
		private readonly IContratFournisseurService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public ContratFournisseurBLL(IContratFournisseurService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<ContratFournisseurListe>> ObtenireContratFournisseurListe()
		{
			var result = new WebApiListResponse<ContratFournisseurListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireContratFournisseurListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<ContratFournisseurListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ContratFournisseurReponse>> ObtenireContratFournisseurParId(int Id)
		{
			var result = new WebApiSingleResponse<ContratFournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireContratFournisseurParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<ContratFournisseurReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ContratFournisseurReponse>> CreationContratFournisseur(ContratFournisseurRequest entity)
		{
			var result = new WebApiSingleResponse<ContratFournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationContratFournisseur(_mapper.Map<ContratFournisseur>(entity));
				result.Model = new ContratFournisseurReponse { ContratFournisseurID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ContratFournisseurReponse>> MisejourContratFournisseur(ContratFournisseurEdit entity)
		{
			var result = new WebApiSingleResponse<ContratFournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourContratFournisseur(_mapper.Map<ContratFournisseur>(entity));
				result.Model = new ContratFournisseurReponse { ContratFournisseurID = entity.ContratFournisseurID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<ContratFournisseurReponse>> SuppressionContratFournisseur(int id)
		{
			var result = new WebApiSingleResponse<ContratFournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireContratFournisseurParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionContratFournisseur(id);
				result.Model = new ContratFournisseurReponse { ContratFournisseurID = id };
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
