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
{	[Route("api/statutoperations")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class StatutOperationController : ControllerBase
	{

		private readonly IStatutOperationBLL _statutoperationBLL;
		private readonly ILogger<StatutOperationController> _logger;
		public StatutOperationController(IStatutOperationBLL statutoperationBLL, ILogger<StatutOperationController> logger)
		{
			_statutoperationBLL = statutoperationBLL ?? throw new ArgumentNullException(nameof(statutoperationBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<StatutOperationListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _statutoperationBLL.ObtenireStatutOperationListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id statutoperation</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<StatutOperationReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _statutoperationBLL.ObtenireStatutOperationParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<StatutOperationReponse>>> CreationAsync([FromBody] StatutOperationRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<StatutOperationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _statutoperationBLL.CreationStatutOperation(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="statutoperationid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{statutoperationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<StatutOperationReponse>>> MisejourAsync(int statutoperationid, [FromBody] StatutOperationEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<StatutOperationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _statutoperationBLL.MisejourStatutOperation(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="statutoperationid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{statutoperationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<StatutOperationReponse>>> SuppressionAsync(int statutoperationid)
		{
			var response = await _statutoperationBLL.SuppressionStatutOperation(statutoperationid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
