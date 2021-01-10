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
{	[Route("api/comptabilites")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ComptabiliteController : ControllerBase
	{

		private readonly IComptabiliteBLL _comptabiliteBLL;
		private readonly ILogger<ComptabiliteController> _logger;
		public ComptabiliteController(IComptabiliteBLL comptabiliteBLL, ILogger<ComptabiliteController> logger)
		{
			_comptabiliteBLL = comptabiliteBLL ?? throw new ArgumentNullException(nameof(comptabiliteBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ComptabiliteListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _comptabiliteBLL.ObtenireComptabiliteListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id comptabilite</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ComptabiliteReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _comptabiliteBLL.ObtenireComptabiliteParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ComptabiliteReponse>>> CreationAsync([FromBody] ComptabiliteRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ComptabiliteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _comptabiliteBLL.CreationComptabilite(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="comptabiliteid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{comptabiliteid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ComptabiliteReponse>>> MisejourAsync(int comptabiliteid, [FromBody] ComptabiliteEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ComptabiliteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _comptabiliteBLL.MisejourComptabilite(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="comptabiliteid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{comptabiliteid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ComptabiliteReponse>>> SuppressionAsync(int comptabiliteid)
		{
			var response = await _comptabiliteBLL.SuppressionComptabilite(comptabiliteid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
