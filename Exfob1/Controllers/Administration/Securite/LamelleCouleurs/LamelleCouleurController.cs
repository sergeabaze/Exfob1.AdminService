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
{	[Route("api/lamellecouleurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class LamelleCouleurController : ControllerBase
	{

		private readonly ILamelleCouleurBLL _lamellecouleurBLL;
		private readonly ILogger<LamelleCouleurController> _logger;
		public LamelleCouleurController(ILamelleCouleurBLL lamellecouleurBLL, ILogger<LamelleCouleurController> logger)
		{
			_lamellecouleurBLL = lamellecouleurBLL ?? throw new ArgumentNullException(nameof(lamellecouleurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<LamelleCouleurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _lamellecouleurBLL.ObtenireLamelleCouleurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id lamellecouleur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<LamelleCouleurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _lamellecouleurBLL.ObtenireLamelleCouleurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<LamelleCouleurReponse>>> CreationAsync([FromBody] LamelleCouleurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LamelleCouleurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _lamellecouleurBLL.CreationLamelleCouleur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="lamellecouleurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{lamellecouleurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LamelleCouleurReponse>>> MisejourAsync(int lamellecouleurid, [FromBody] LamelleCouleurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LamelleCouleurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _lamellecouleurBLL.MisejourLamelleCouleur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="lamellecouleurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{lamellecouleurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LamelleCouleurReponse>>> SuppressionAsync(int lamellecouleurid)
		{
			var response = await _lamellecouleurBLL.SuppressionLamelleCouleur(lamellecouleurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
