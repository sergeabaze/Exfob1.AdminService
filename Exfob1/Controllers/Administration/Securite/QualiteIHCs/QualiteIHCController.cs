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
{	[Route("api/qualiteihcs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class QualiteIHCController : ControllerBase
	{

		private readonly IQualiteIHCBLL _qualiteihcBLL;
		private readonly ILogger<QualiteIHCController> _logger;
		public QualiteIHCController(IQualiteIHCBLL qualiteihcBLL, ILogger<QualiteIHCController> logger)
		{
			_qualiteihcBLL = qualiteihcBLL ?? throw new ArgumentNullException(nameof(qualiteihcBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<QualiteIHCListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _qualiteihcBLL.ObtenireQualiteIHCListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id qualiteihc</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<QualiteIHCReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _qualiteihcBLL.ObtenireQualiteIHCParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<QualiteIHCReponse>>> CreationAsync([FromBody] QualiteIHCRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<QualiteIHCReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _qualiteihcBLL.CreationQualiteIHC(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="qualiteihcid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{qualiteihcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<QualiteIHCReponse>>> MisejourAsync(int qualiteihcid, [FromBody] QualiteIHCEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<QualiteIHCReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _qualiteihcBLL.MisejourQualiteIHC(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="qualiteihcid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{qualiteihcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<QualiteIHCReponse>>> SuppressionAsync(int qualiteihcid)
		{
			var response = await _qualiteihcBLL.SuppressionQualiteIHC(qualiteihcid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
