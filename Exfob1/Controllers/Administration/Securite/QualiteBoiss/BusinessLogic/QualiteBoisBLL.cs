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
	public class QualiteBoisBLL : IQualiteBoisBLL
	{
		private readonly IQualiteBoisService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public QualiteBoisBLL(IQualiteBoisService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<QualiteBoisListe>> ObtenireQualiteBoisListe()
		{
			var result = new WebApiListResponse<QualiteBoisListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteBoisListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<QualiteBoisListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteBoisReponse>> ObtenireQualiteBoisParId(int Id)
		{
			var result = new WebApiSingleResponse<QualiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteBoisParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<QualiteBoisReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteBoisReponse>> CreationQualiteBois(QualiteBoisRequest entity)
		{
			var result = new WebApiSingleResponse<QualiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationQualiteBois(_mapper.Map<QualiteBois>(entity));
				result.Model = new QualiteBoisReponse { QualiteBoisID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteBoisReponse>> MisejourQualiteBois(QualiteBoisEdit entity)
		{
			var result = new WebApiSingleResponse<QualiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourQualiteBois(_mapper.Map<QualiteBois>(entity));
				result.Model = new QualiteBoisReponse { QualiteBoisID = entity.QualiteBoisID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteBoisReponse>> SuppressionQualiteBois(int id)
		{
			var result = new WebApiSingleResponse<QualiteBoisReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteBoisParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionQualiteBois(id);
				result.Model = new QualiteBoisReponse { QualiteBoisID = id };
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
