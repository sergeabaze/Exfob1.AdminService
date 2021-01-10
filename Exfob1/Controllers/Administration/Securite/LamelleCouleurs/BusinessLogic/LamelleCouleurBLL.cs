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
	public class LamelleCouleurBLL : ILamelleCouleurBLL
	{
		private readonly ILamelleCouleurService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public LamelleCouleurBLL(ILamelleCouleurService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<LamelleCouleurListe>> ObtenireLamelleCouleurListe()
		{
			var result = new WebApiListResponse<LamelleCouleurListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleCouleurListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<LamelleCouleurListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleCouleurReponse>> ObtenireLamelleCouleurParId(int Id)
		{
			var result = new WebApiSingleResponse<LamelleCouleurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleCouleurParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<LamelleCouleurReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleCouleurReponse>> CreationLamelleCouleur(LamelleCouleurRequest entity)
		{
			var result = new WebApiSingleResponse<LamelleCouleurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationLamelleCouleur(_mapper.Map<LamelleCouleur>(entity));
				result.Model = new LamelleCouleurReponse { LamelleCouleurID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleCouleurReponse>> MisejourLamelleCouleur(LamelleCouleurEdit entity)
		{
			var result = new WebApiSingleResponse<LamelleCouleurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourLamelleCouleur(_mapper.Map<LamelleCouleur>(entity));
				result.Model = new LamelleCouleurReponse { LamelleCouleurID = entity.LamelleCouleurID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<LamelleCouleurReponse>> SuppressionLamelleCouleur(int id)
		{
			var result = new WebApiSingleResponse<LamelleCouleurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireLamelleCouleurParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionLamelleCouleur(id);
				result.Model = new LamelleCouleurReponse { LamelleCouleurID = id };
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
