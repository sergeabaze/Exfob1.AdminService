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
{	[Route("api/parcs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ParcController : ControllerBase
	{

		private readonly IParcBLL _parcBLL;
		private readonly ILogger<ParcController> _logger;
		public ParcController(IParcBLL parcBLL, ILogger<ParcController> logger)
		{
			_parcBLL = parcBLL ?? throw new ArgumentNullException(nameof(parcBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ParcListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _parcBLL.ObtenireParcListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id parc</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ParcReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _parcBLL.ObtenireParcParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ParcReponse>>> CreationAsync([FromBody] ParcRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ParcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _parcBLL.CreationParc(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="parcid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{parcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ParcReponse>>> MisejourAsync(int parcid, [FromBody] ParcEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ParcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _parcBLL.MisejourParc(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="parcid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{parcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ParcReponse>>> SuppressionAsync(int parcid)
		{
			var response = await _parcBLL.SuppressionParc(parcid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
