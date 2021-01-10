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
{	[Route("api/acconiers")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class AcconierController : ControllerBase
	{

		private readonly IAcconierBLL _acconierBLL;
		private readonly ILogger<AcconierController> _logger;
		public AcconierController(IAcconierBLL acconierBLL, ILogger<AcconierController> logger)
		{
			_acconierBLL = acconierBLL ?? throw new ArgumentNullException(nameof(acconierBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<AcconierListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _acconierBLL.ObtenireAcconierListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id acconier</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<AcconierReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _acconierBLL.ObtenireAcconierParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<AcconierReponse>>> CreationAsync([FromBody] AcconierRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<AcconierReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _acconierBLL.CreationAcconier(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="acconierid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{acconierid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<AcconierReponse>>> MisejourAsync(int acconierid, [FromBody] AcconierEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<AcconierReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _acconierBLL.MisejourAcconier(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="acconierid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{acconierid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<AcconierReponse>>> SuppressionAsync(int acconierid)
		{
			var response = await _acconierBLL.SuppressionAcconier(acconierid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
