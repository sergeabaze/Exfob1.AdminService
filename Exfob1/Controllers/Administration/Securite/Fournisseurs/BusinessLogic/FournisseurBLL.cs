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
	public class FournisseurBLL : IFournisseurBLL
	{
		private readonly IFournisseurService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public FournisseurBLL(IFournisseurService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<FournisseurListe>> ObtenireFournisseurListe()
		{
			var result = new WebApiListResponse<FournisseurListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireFournisseurListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<FournisseurListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<FournisseurReponse>> ObtenireFournisseurParId(int Id)
		{
			var result = new WebApiSingleResponse<FournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireFournisseurParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<FournisseurReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<FournisseurReponse>> CreationFournisseur(FournisseurRequest entity)
		{
			var result = new WebApiSingleResponse<FournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationFournisseur(_mapper.Map<Fournisseur>(entity));
				result.Model = new FournisseurReponse { FournisseurID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<FournisseurReponse>> MisejourFournisseur(FournisseurEdit entity)
		{
			var result = new WebApiSingleResponse<FournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourFournisseur(_mapper.Map<Fournisseur>(entity));
				result.Model = new FournisseurReponse { FournisseurID = entity.FournisseurID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<FournisseurReponse>> SuppressionFournisseur(int id)
		{
			var result = new WebApiSingleResponse<FournisseurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireFournisseurParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionFournisseur(id);
				result.Model = new FournisseurReponse { FournisseurID = id };
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
