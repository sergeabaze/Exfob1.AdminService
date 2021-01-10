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
{	[Route("api/typefournisseurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeFournisseurController : ControllerBase
	{

		private readonly ITypeFournisseurBLL _typefournisseurBLL;
		private readonly ILogger<TypeFournisseurController> _logger;
		public TypeFournisseurController(ITypeFournisseurBLL typefournisseurBLL, ILogger<TypeFournisseurController> logger)
		{
			_typefournisseurBLL = typefournisseurBLL ?? throw new ArgumentNullException(nameof(typefournisseurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeFournisseurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typefournisseurBLL.ObtenireTypeFournisseurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typefournisseur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeFournisseurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typefournisseurBLL.ObtenireTypeFournisseurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeFournisseurReponse>>> CreationAsync([FromBody] TypeFournisseurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeFournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typefournisseurBLL.CreationTypeFournisseur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typefournisseurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typefournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeFournisseurReponse>>> MisejourAsync(int typefournisseurid, [FromBody] TypeFournisseurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeFournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typefournisseurBLL.MisejourTypeFournisseur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typefournisseurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typefournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeFournisseurReponse>>> SuppressionAsync(int typefournisseurid)
		{
			var response = await _typefournisseurBLL.SuppressionTypeFournisseur(typefournisseurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
