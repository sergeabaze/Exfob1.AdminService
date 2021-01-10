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
{	[Route("api/comptetierss")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class CompteTiersController : ControllerBase
	{

		private readonly ICompteTiersBLL _comptetiersBLL;
		private readonly ILogger<CompteTiersController> _logger;
		public CompteTiersController(ICompteTiersBLL comptetiersBLL, ILogger<CompteTiersController> logger)
		{
			_comptetiersBLL = comptetiersBLL ?? throw new ArgumentNullException(nameof(comptetiersBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<CompteTiersListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _comptetiersBLL.ObtenireCompteTiersListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id comptetiers</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<CompteTiersReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _comptetiersBLL.ObtenireCompteTiersParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<CompteTiersReponse>>> CreationAsync([FromBody] CompteTiersRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CompteTiersReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _comptetiersBLL.CreationCompteTiers(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="comptetiersid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{comptetiersid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CompteTiersReponse>>> MisejourAsync(int comptetiersid, [FromBody] CompteTiersEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CompteTiersReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _comptetiersBLL.MisejourCompteTiers(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="comptetiersid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{comptetiersid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CompteTiersReponse>>> SuppressionAsync(int comptetiersid)
		{
			var response = await _comptetiersBLL.SuppressionCompteTiers(comptetiersid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
