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
{	[Route("api/modepaiements")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ModePaiementController : ControllerBase
	{

		private readonly IModePaiementBLL _modepaiementBLL;
		private readonly ILogger<ModePaiementController> _logger;
		public ModePaiementController(IModePaiementBLL modepaiementBLL, ILogger<ModePaiementController> logger)
		{
			_modepaiementBLL = modepaiementBLL ?? throw new ArgumentNullException(nameof(modepaiementBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ModePaiementListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _modepaiementBLL.ObtenireModePaiementListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id modepaiement</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ModePaiementReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _modepaiementBLL.ObtenireModePaiementParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ModePaiementReponse>>> CreationAsync([FromBody] ModePaiementRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModePaiementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _modepaiementBLL.CreationModePaiement(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="modepaiementid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{modepaiementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModePaiementReponse>>> MisejourAsync(int modepaiementid, [FromBody] ModePaiementEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModePaiementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _modepaiementBLL.MisejourModePaiement(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="modepaiementid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{modepaiementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModePaiementReponse>>> SuppressionAsync(int modepaiementid)
		{
			var response = await _modepaiementBLL.SuppressionModePaiement(modepaiementid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
