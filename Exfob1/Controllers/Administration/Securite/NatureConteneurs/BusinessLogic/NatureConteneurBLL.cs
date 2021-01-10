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
	public class NatureConteneurBLL : INatureConteneurBLL
	{
		private readonly INatureConteneurService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public NatureConteneurBLL(INatureConteneurService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<NatureConteneurListe>> ObtenireNatureConteneurListe()
		{
			var result = new WebApiListResponse<NatureConteneurListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureConteneurListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<NatureConteneurListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureConteneurReponse>> ObtenireNatureConteneurParId(int Id)
		{
			var result = new WebApiSingleResponse<NatureConteneurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureConteneurParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<NatureConteneurReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureConteneurReponse>> CreationNatureConteneur(NatureConteneurRequest entity)
		{
			var result = new WebApiSingleResponse<NatureConteneurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationNatureConteneur(_mapper.Map<NatureConteneur>(entity));
				result.Model = new NatureConteneurReponse { NatureConteneurID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureConteneurReponse>> MisejourNatureConteneur(NatureConteneurEdit entity)
		{
			var result = new WebApiSingleResponse<NatureConteneurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourNatureConteneur(_mapper.Map<NatureConteneur>(entity));
				result.Model = new NatureConteneurReponse { NatureConteneurID = entity.NatureConteneurID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<NatureConteneurReponse>> SuppressionNatureConteneur(int id)
		{
			var result = new WebApiSingleResponse<NatureConteneurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireNatureConteneurParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionNatureConteneur(id);
				result.Model = new NatureConteneurReponse { NatureConteneurID = id };
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
