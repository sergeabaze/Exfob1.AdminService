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
	public class QualiteIHCBLL : IQualiteIHCBLL
	{
		private readonly IQualiteIHCService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public QualiteIHCBLL(IQualiteIHCService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<QualiteIHCListe>> ObtenireQualiteIHCListe()
		{
			var result = new WebApiListResponse<QualiteIHCListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteIHCListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<QualiteIHCListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteIHCReponse>> ObtenireQualiteIHCParId(int Id)
		{
			var result = new WebApiSingleResponse<QualiteIHCReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteIHCParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<QualiteIHCReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteIHCReponse>> CreationQualiteIHC(QualiteIHCRequest entity)
		{
			var result = new WebApiSingleResponse<QualiteIHCReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationQualiteIHC(_mapper.Map<QualiteIHC>(entity));
				result.Model = new QualiteIHCReponse { QualiteIHCID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteIHCReponse>> MisejourQualiteIHC(QualiteIHCEdit entity)
		{
			var result = new WebApiSingleResponse<QualiteIHCReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourQualiteIHC(_mapper.Map<QualiteIHC>(entity));
				result.Model = new QualiteIHCReponse { QualiteIHCID = entity.QualiteIHCID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<QualiteIHCReponse>> SuppressionQualiteIHC(int id)
		{
			var result = new WebApiSingleResponse<QualiteIHCReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireQualiteIHCParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionQualiteIHC(id);
				result.Model = new QualiteIHCReponse { QualiteIHCID = id };
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
