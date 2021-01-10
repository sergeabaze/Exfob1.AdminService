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
{	[Route("api/portembarquements")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PortEmbarquementController : ControllerBase
	{

		private readonly IPortEmbarquementBLL _portembarquementBLL;
		private readonly ILogger<PortEmbarquementController> _logger;
		public PortEmbarquementController(IPortEmbarquementBLL portembarquementBLL, ILogger<PortEmbarquementController> logger)
		{
			_portembarquementBLL = portembarquementBLL ?? throw new ArgumentNullException(nameof(portembarquementBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PortEmbarquementListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _portembarquementBLL.ObtenirePortEmbarquementListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id portembarquement</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PortEmbarquementReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _portembarquementBLL.ObtenirePortEmbarquementParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PortEmbarquementReponse>>> CreationAsync([FromBody] PortEmbarquementRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortEmbarquementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _portembarquementBLL.CreationPortEmbarquement(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="portembarquementid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{portembarquementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortEmbarquementReponse>>> MisejourAsync(int portembarquementid, [FromBody] PortEmbarquementEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortEmbarquementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _portembarquementBLL.MisejourPortEmbarquement(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="portembarquementid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{portembarquementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortEmbarquementReponse>>> SuppressionAsync(int portembarquementid)
		{
			var response = await _portembarquementBLL.SuppressionPortEmbarquement(portembarquementid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
