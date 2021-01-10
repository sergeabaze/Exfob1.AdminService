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
{	[Route("api/droits")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class DroitController : ControllerBase
	{

		private readonly IDroitBLL _droitBLL;
		private readonly ILogger<DroitController> _logger;
		public DroitController(IDroitBLL droitBLL, ILogger<DroitController> logger)
		{
			_droitBLL = droitBLL ?? throw new ArgumentNullException(nameof(droitBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<DroitListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _droitBLL.ObtenireDroitListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id droit</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<DroitReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _droitBLL.ObtenireDroitParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<DroitReponse>>> CreationAsync([FromBody] DroitRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DroitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _droitBLL.CreationDroit(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="droitid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{droitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DroitReponse>>> MisejourAsync(int droitid, [FromBody] DroitEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DroitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _droitBLL.MisejourDroit(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="droitid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{droitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DroitReponse>>> SuppressionAsync(int droitid)
		{
			var response = await _droitBLL.SuppressionDroit(droitid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
