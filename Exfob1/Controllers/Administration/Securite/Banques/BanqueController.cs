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
{	[Route("api/banques")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class BanqueController : ControllerBase
	{

		private readonly IBanqueBLL _banqueBLL;
		private readonly ILogger<BanqueController> _logger;
		public BanqueController(IBanqueBLL banqueBLL, ILogger<BanqueController> logger)
		{
			_banqueBLL = banqueBLL ?? throw new ArgumentNullException(nameof(banqueBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<BanqueListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _banqueBLL.ObtenireBanqueListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id banque</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<BanqueReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _banqueBLL.ObtenireBanqueParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<BanqueReponse>>> CreationAsync([FromBody] BanqueRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<BanqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _banqueBLL.CreationBanque(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="banqueid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{banqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<BanqueReponse>>> MisejourAsync(int banqueid, [FromBody] BanqueEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<BanqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _banqueBLL.MisejourBanque(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="banqueid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{banqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<BanqueReponse>>> SuppressionAsync(int banqueid)
		{
			var response = await _banqueBLL.SuppressionBanque(banqueid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
