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
{	[Route("api/qualiteboiss")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class QualiteBoisController : ControllerBase
	{

		private readonly IQualiteBoisBLL _qualiteboisBLL;
		private readonly ILogger<QualiteBoisController> _logger;
		public QualiteBoisController(IQualiteBoisBLL qualiteboisBLL, ILogger<QualiteBoisController> logger)
		{
			_qualiteboisBLL = qualiteboisBLL ?? throw new ArgumentNullException(nameof(qualiteboisBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<QualiteBoisListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _qualiteboisBLL.ObtenireQualiteBoisListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id qualitebois</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<QualiteBoisReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _qualiteboisBLL.ObtenireQualiteBoisParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<QualiteBoisReponse>>> CreationAsync([FromBody] QualiteBoisRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<QualiteBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _qualiteboisBLL.CreationQualiteBois(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="qualiteboisid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{qualiteboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<QualiteBoisReponse>>> MisejourAsync(int qualiteboisid, [FromBody] QualiteBoisEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<QualiteBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _qualiteboisBLL.MisejourQualiteBois(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="qualiteboisid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{qualiteboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<QualiteBoisReponse>>> SuppressionAsync(int qualiteboisid)
		{
			var response = await _qualiteboisBLL.SuppressionQualiteBois(qualiteboisid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
