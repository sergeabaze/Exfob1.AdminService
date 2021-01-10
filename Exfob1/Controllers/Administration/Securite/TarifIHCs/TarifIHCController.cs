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
{	[Route("api/tarifihcs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TarifIHCController : ControllerBase
	{

		private readonly ITarifIHCBLL _tarifihcBLL;
		private readonly ILogger<TarifIHCController> _logger;
		public TarifIHCController(ITarifIHCBLL tarifihcBLL, ILogger<TarifIHCController> logger)
		{
			_tarifihcBLL = tarifihcBLL ?? throw new ArgumentNullException(nameof(tarifihcBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TarifIHCListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _tarifihcBLL.ObtenireTarifIHCListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id tarifihc</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TarifIHCReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _tarifihcBLL.ObtenireTarifIHCParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TarifIHCReponse>>> CreationAsync([FromBody] TarifIHCRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TarifIHCReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _tarifihcBLL.CreationTarifIHC(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="tarifihcid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{tarifihcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TarifIHCReponse>>> MisejourAsync(int tarifihcid, [FromBody] TarifIHCEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TarifIHCReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _tarifihcBLL.MisejourTarifIHC(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="tarifihcid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{tarifihcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TarifIHCReponse>>> SuppressionAsync(int tarifihcid)
		{
			var response = await _tarifihcBLL.SuppressionTarifIHC(tarifihcid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
