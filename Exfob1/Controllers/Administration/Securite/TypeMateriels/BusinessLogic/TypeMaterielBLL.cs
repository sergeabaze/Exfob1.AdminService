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
	public class TypeMaterielBLL : ITypeMaterielBLL
	{
		private readonly ITypeMaterielService _service;
		private readonly IMapper _mapper;
		#region Constructeurs
		public TypeMaterielBLL(ITypeMaterielService service, IMapper mapper)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_mapper = mapper;
		}

		#endregion

		#region Pulic methods
		public async  Task<WebApiListResponse<TypeMaterielListe>> ObtenireTypeMaterielListe()
		{
			var result = new WebApiListResponse<TypeMaterielListe>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeMaterielListe();
				if (!query.Any())
				{
					return CommunValidators.NotFoundRequestMessage(
					   result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<IEnumerable<TypeMaterielListe>>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeMaterielReponse>> ObtenireTypeMaterielParId(int Id)
		{
			var result = new WebApiSingleResponse<TypeMaterielReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeMaterielParId(Id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					     result, ResourceMessage.ErrurNotFound);
				}

				result.Model = _mapper.Map<TypeMaterielReponse>(query);
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				    result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeMaterielReponse>> CreationTypeMateriel(TypeMaterielRequest entity)
		{
			var result = new WebApiSingleResponse<TypeMaterielReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{

				var id = await _service.CreationTypeMateriel(_mapper.Map<TypeMateriel>(entity));
				result.Model = new TypeMaterielReponse { TypeMaterielID = id };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeMaterielReponse>> MisejourTypeMateriel(TypeMaterielEdit entity)
		{
			var result = new WebApiSingleResponse<TypeMaterielReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				await _service.MisejourTypeMateriel(_mapper.Map<TypeMateriel>(entity));
				result.Model = new TypeMaterielReponse { TypeMaterielID = entity.TypeMaterielID };
				result.Message = ResourceMessage.Message001;

			}
			catch (Exception ex)
			{
				result = CommunValidators.ExceptionRequestMessage(
				     result, ex.Message);
			}
			return result;
		}

		public async  Task<WebApiSingleResponse<TypeMaterielReponse>> SuppressionTypeMateriel(int id)
		{
			var result = new WebApiSingleResponse<TypeMaterielReponse>
			{
				CodeMessage = StatusCodes.Status200OK,
				IsError = false,
			};

			try
			{
				var query = await _service.ObtenireTypeMaterielParId(id);
				if (query == null)
				{
					return CommunValidators.NotFoundRequestMessage(
					    result, ResourceMessage.ErrurNotFound_Suppression);
				}
				await _service.SuppressionTypeMateriel(id);
				result.Model = new TypeMaterielReponse { TypeMaterielID = id };
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
