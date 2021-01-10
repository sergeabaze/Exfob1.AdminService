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
	public class CodePlaquetteBLL : ICodePlaquetteBLL
	{
		private readonly ICodePlaquetteService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public CodePlaquetteBLL(ICodePlaquetteService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<CodePlaquetteListe>> ObtenireCodePlaquetteListe()
		{
			var result = new WebApiListResponse<CodePlaquetteListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCodePlaquetteListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<CodePlaquetteListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CodePlaquetteReponse>> ObtenireCodePlaquetteParId(int Id)
		{
			var result = new WebApiSingleResponse<CodePlaquetteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCodePlaquetteParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<CodePlaquetteReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CodePlaquetteReponse>> CreationCodePlaquette(CodePlaquetteRequest entity)
		{
			var result = new WebApiSingleResponse<CodePlaquetteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationCodePlaquette(_mapper.Map<CodePlaquette>(entity));
				result.Model = new CodePlaquetteReponse { CodePlaquetteID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CodePlaquetteReponse>> MisejourCodePlaquette(CodePlaquetteEdit entity)
		{
			var result = new WebApiSingleResponse<CodePlaquetteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourCodePlaquette(_mapper.Map<CodePlaquette>(entity));
				result.Model = new CodePlaquetteReponse { CodePlaquetteID = entity.CodePlaquetteID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<CodePlaquetteReponse>> SuppressionCodePlaquette(int id)
		{
			var result = new WebApiSingleResponse<CodePlaquetteReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireCodePlaquetteParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionCodePlaquette(id);
				result.Model = new CodePlaquetteReponse { CodePlaquetteID = id };
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
