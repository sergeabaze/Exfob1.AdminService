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
{	[Route("api/natureparcs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NatureParcController : ControllerBase
	{

		private readonly INatureParcBLL _natureparcBLL;
		private readonly ILogger<NatureParcController> _logger;
		public NatureParcController(INatureParcBLL natureparcBLL, ILogger<NatureParcController> logger)
		{
			_natureparcBLL = natureparcBLL ?? throw new ArgumentNullException(nameof(natureparcBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NatureParcListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _natureparcBLL.ObtenireNatureParcListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id natureparc</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NatureParcReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _natureparcBLL.ObtenireNatureParcParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NatureParcReponse>>> CreationAsync([FromBody] NatureParcRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureParcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _natureparcBLL.CreationNatureParc(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="natureparcid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{natureparcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureParcReponse>>> MisejourAsync(int natureparcid, [FromBody] NatureParcEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureParcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _natureparcBLL.MisejourNatureParc(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="natureparcid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{natureparcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureParcReponse>>> SuppressionAsync(int natureparcid)
		{
			var response = await _natureparcBLL.SuppressionNatureParc(natureparcid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
