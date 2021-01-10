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
{	[Route("api/payss")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PaysController : ControllerBase
	{

		private readonly IPaysBLL _paysBLL;
		private readonly ILogger<PaysController> _logger;
		public PaysController(IPaysBLL paysBLL, ILogger<PaysController> logger)
		{
			_paysBLL = paysBLL ?? throw new ArgumentNullException(nameof(paysBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PaysListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _paysBLL.ObtenirePaysListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id pays</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PaysReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _paysBLL.ObtenirePaysParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PaysReponse>>> CreationAsync([FromBody] PaysRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PaysReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _paysBLL.CreationPays(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="paysid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{paysid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PaysReponse>>> MisejourAsync(int paysid, [FromBody] PaysEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PaysReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _paysBLL.MisejourPays(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="paysid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{paysid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PaysReponse>>> SuppressionAsync(int paysid)
		{
			var response = await _paysBLL.SuppressionPays(paysid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
