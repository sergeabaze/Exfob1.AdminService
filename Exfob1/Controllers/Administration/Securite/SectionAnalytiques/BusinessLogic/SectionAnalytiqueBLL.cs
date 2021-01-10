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
	public class SectionAnalytiqueBLL : ISectionAnalytiqueBLL
	{
		private readonly ISectionAnalytiqueService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public SectionAnalytiqueBLL(ISectionAnalytiqueService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<SectionAnalytiqueListe>> ObtenireSectionAnalytiqueListe()
		{
			var result = new WebApiListResponse<SectionAnalytiqueListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSectionAnalytiqueListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<SectionAnalytiqueListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SectionAnalytiqueReponse>> ObtenireSectionAnalytiqueParId(int Id)
		{
			var result = new WebApiSingleResponse<SectionAnalytiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSectionAnalytiqueParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<SectionAnalytiqueReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SectionAnalytiqueReponse>> CreationSectionAnalytique(SectionAnalytiqueRequest entity)
		{
			var result = new WebApiSingleResponse<SectionAnalytiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationSectionAnalytique(_mapper.Map<SectionAnalytique>(entity));
				result.Model = new SectionAnalytiqueReponse { SectionAnalytiqueID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SectionAnalytiqueReponse>> MisejourSectionAnalytique(SectionAnalytiqueEdit entity)
		{
			var result = new WebApiSingleResponse<SectionAnalytiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourSectionAnalytique(_mapper.Map<SectionAnalytique>(entity));
				result.Model = new SectionAnalytiqueReponse { SectionAnalytiqueID = entity.SectionAnalytiqueID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<SectionAnalytiqueReponse>> SuppressionSectionAnalytique(int id)
		{
			var result = new WebApiSingleResponse<SectionAnalytiqueReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireSectionAnalytiqueParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionSectionAnalytique(id);
				result.Model = new SectionAnalytiqueReponse { SectionAnalytiqueID = id };
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
