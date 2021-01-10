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
{	[Route("api/societes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SocieteController : ControllerBase
	{

		private readonly ISocieteBLL _societeBLL;
		private readonly ILogger<SocieteController> _logger;
		public SocieteController(ISocieteBLL societeBLL, ILogger<SocieteController> logger)
		{
			_societeBLL = societeBLL ?? throw new ArgumentNullException(nameof(societeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SocieteListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _societeBLL.ObtenireSocieteListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id societe</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SocieteReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _societeBLL.ObtenireSocieteParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SocieteReponse>>> CreationAsync([FromBody] SocieteRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SocieteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _societeBLL.CreationSociete(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="societeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{societeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SocieteReponse>>> MisejourAsync(int societeid, [FromBody] SocieteEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SocieteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _societeBLL.MisejourSociete(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="societeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{societeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SocieteReponse>>> SuppressionAsync(int societeid)
		{
			var response = await _societeBLL.SuppressionSociete(societeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
