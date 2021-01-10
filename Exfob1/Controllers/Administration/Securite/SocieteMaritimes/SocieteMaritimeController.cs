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
{	[Route("api/societemaritimes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SocieteMaritimeController : ControllerBase
	{

		private readonly ISocieteMaritimeBLL _societemaritimeBLL;
		private readonly ILogger<SocieteMaritimeController> _logger;
		public SocieteMaritimeController(ISocieteMaritimeBLL societemaritimeBLL, ILogger<SocieteMaritimeController> logger)
		{
			_societemaritimeBLL = societemaritimeBLL ?? throw new ArgumentNullException(nameof(societemaritimeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SocieteMaritimeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _societemaritimeBLL.ObtenireSocieteMaritimeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id societemaritime</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SocieteMaritimeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _societemaritimeBLL.ObtenireSocieteMaritimeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SocieteMaritimeReponse>>> CreationAsync([FromBody] SocieteMaritimeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SocieteMaritimeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _societemaritimeBLL.CreationSocieteMaritime(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="societemaritimeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{societemaritimeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SocieteMaritimeReponse>>> MisejourAsync(int societemaritimeid, [FromBody] SocieteMaritimeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SocieteMaritimeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _societemaritimeBLL.MisejourSocieteMaritime(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="societemaritimeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{societemaritimeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SocieteMaritimeReponse>>> SuppressionAsync(int societemaritimeid)
		{
			var response = await _societemaritimeBLL.SuppressionSocieteMaritime(societemaritimeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
