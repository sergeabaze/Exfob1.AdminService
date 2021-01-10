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
	public class EquipeOperateurBLL : IEquipeOperateurBLL
	{
		private readonly IEquipeOperateurService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public EquipeOperateurBLL(IEquipeOperateurService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<EquipeOperateurListe>> ObtenireEquipeOperateurListe()
		{
			var result = new WebApiListResponse<EquipeOperateurListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireEquipeOperateurListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<EquipeOperateurListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<EquipeOperateurReponse>> ObtenireEquipeOperateurParId(int Id)
		{
			var result = new WebApiSingleResponse<EquipeOperateurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireEquipeOperateurParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<EquipeOperateurReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<EquipeOperateurReponse>> CreationEquipeOperateur(EquipeOperateurRequest entity)
		{
			var result = new WebApiSingleResponse<EquipeOperateurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationEquipeOperateur(_mapper.Map<EquipeOperateur>(entity));
				result.Model = new EquipeOperateurReponse { EquipeID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<EquipeOperateurReponse>> MisejourEquipeOperateur(EquipeOperateurEdit entity)
		{
			var result = new WebApiSingleResponse<EquipeOperateurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourEquipeOperateur(_mapper.Map<EquipeOperateur>(entity));
				result.Model = new EquipeOperateurReponse { EquipeID = entity.EquipeOperateurID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<EquipeOperateurReponse>> SuppressionEquipeOperateur(int id)
		{
			var result = new WebApiSingleResponse<EquipeOperateurReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireEquipeOperateurParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionEquipeOperateur(id);
				result.Model = new EquipeOperateurReponse { EquipeID = id };
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
