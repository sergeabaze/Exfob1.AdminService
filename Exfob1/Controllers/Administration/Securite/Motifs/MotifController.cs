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
{	[Route("api/motifs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class MotifController : ControllerBase
	{

		private readonly IMotifBLL _motifBLL;
		private readonly ILogger<MotifController> _logger;
		public MotifController(IMotifBLL motifBLL, ILogger<MotifController> logger)
		{
			_motifBLL = motifBLL ?? throw new ArgumentNullException(nameof(motifBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<MotifListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _motifBLL.ObtenireMotifListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id motif</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<MotifReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _motifBLL.ObtenireMotifParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<MotifReponse>>> CreationAsync([FromBody] MotifRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MotifReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _motifBLL.CreationMotif(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="motifid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{motifid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MotifReponse>>> MisejourAsync(int motifid, [FromBody] MotifEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MotifReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _motifBLL.MisejourMotif(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="motifid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{motifid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MotifReponse>>> SuppressionAsync(int motifid)
		{
			var response = await _motifBLL.SuppressionMotif(motifid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
