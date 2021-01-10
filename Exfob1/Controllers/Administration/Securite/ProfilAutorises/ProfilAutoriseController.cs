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
{	[Route("api/profilautorises")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ProfilAutoriseController : ControllerBase
	{

		private readonly IProfilAutoriseBLL _profilautoriseBLL;
		private readonly ILogger<ProfilAutoriseController> _logger;
		public ProfilAutoriseController(IProfilAutoriseBLL profilautoriseBLL, ILogger<ProfilAutoriseController> logger)
		{
			_profilautoriseBLL = profilautoriseBLL ?? throw new ArgumentNullException(nameof(profilautoriseBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ProfilAutoriseListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _profilautoriseBLL.ObtenireProfilAutoriseListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id profilautorise</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ProfilAutoriseReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _profilautoriseBLL.ObtenireProfilAutoriseParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ProfilAutoriseReponse>>> CreationAsync([FromBody] ProfilAutoriseRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ProfilAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _profilautoriseBLL.CreationProfilAutorise(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="profilautoriseid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{profilautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ProfilAutoriseReponse>>> MisejourAsync(int profilautoriseid, [FromBody] ProfilAutoriseEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ProfilAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _profilautoriseBLL.MisejourProfilAutorise(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="profilautoriseid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{profilautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ProfilAutoriseReponse>>> SuppressionAsync(int profilautoriseid)
		{
			var response = await _profilautoriseBLL.SuppressionProfilAutorise(profilautoriseid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
