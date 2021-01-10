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
{	[Route("api/droitautorises")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class DroitAutoriseController : ControllerBase
	{

		private readonly IDroitAutoriseBLL _droitautoriseBLL;
		private readonly ILogger<DroitAutoriseController> _logger;
		public DroitAutoriseController(IDroitAutoriseBLL droitautoriseBLL, ILogger<DroitAutoriseController> logger)
		{
			_droitautoriseBLL = droitautoriseBLL ?? throw new ArgumentNullException(nameof(droitautoriseBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<DroitAutoriseListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _droitautoriseBLL.ObtenireDroitAutoriseListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id droitautorise</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<DroitAutoriseReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _droitautoriseBLL.ObtenireDroitAutoriseParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<DroitAutoriseReponse>>> CreationAsync([FromBody] DroitAutoriseRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DroitAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _droitautoriseBLL.CreationDroitAutorise(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="droitautoriseid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{droitautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DroitAutoriseReponse>>> MisejourAsync(int droitautoriseid, [FromBody] DroitAutoriseEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DroitAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _droitautoriseBLL.MisejourDroitAutorise(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="droitautoriseid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{droitautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DroitAutoriseReponse>>> SuppressionAsync(int droitautoriseid)
		{
			var response = await _droitautoriseBLL.SuppressionDroitAutorise(droitautoriseid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
