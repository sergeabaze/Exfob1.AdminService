using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Exfob1.Models.Adminstrations;
using Exfob1.Conventions;
using Exfob1.Models;
namespace Exfob1.Controllers.Administration
{	[Route("api/typemateriels")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeMaterielController : ControllerBase
	{

		private readonly ITypeMaterielBLL _typematerielBLL;
		private readonly ILogger<TypeMaterielController> _logger;
		public TypeMaterielController(ITypeMaterielBLL typematerielBLL, ILogger<TypeMaterielController> logger)
		{
			_typematerielBLL = typematerielBLL ?? throw new ArgumentNullException(nameof(typematerielBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeMaterielListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typematerielBLL.ObtenireTypeMaterielListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typemateriel</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeMaterielReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typematerielBLL.ObtenireTypeMaterielParId(id)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de création
		/// </summary>
		/// <param name="request">objet</param>
		/// <returns>objet créer</returns>
		[HttpPost("creation")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeMaterielReponse>>> CreationAsync([FromBody] TypeMaterielRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeMaterielReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typematerielBLL.CreationTypeMateriel(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typematerielid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typematerielid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeMaterielReponse>>> MisejourAsync(int typematerielid, [FromBody] TypeMaterielEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeMaterielReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typematerielBLL.MisejourTypeMateriel(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typematerielid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typematerielid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeMaterielReponse>>> SuppressionAsync(int typematerielid)
		{
			var response = await _typematerielBLL.SuppressionTypeMateriel(typematerielid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
