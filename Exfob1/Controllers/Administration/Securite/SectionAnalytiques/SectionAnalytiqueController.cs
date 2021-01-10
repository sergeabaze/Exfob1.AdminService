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
{	[Route("api/sectionanalytiques")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SectionAnalytiqueController : ControllerBase
	{

		private readonly ISectionAnalytiqueBLL _sectionanalytiqueBLL;
		private readonly ILogger<SectionAnalytiqueController> _logger;
		public SectionAnalytiqueController(ISectionAnalytiqueBLL sectionanalytiqueBLL, ILogger<SectionAnalytiqueController> logger)
		{
			_sectionanalytiqueBLL = sectionanalytiqueBLL ?? throw new ArgumentNullException(nameof(sectionanalytiqueBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SectionAnalytiqueListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sectionanalytiqueBLL.ObtenireSectionAnalytiqueListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id sectionanalytique</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SectionAnalytiqueReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sectionanalytiqueBLL.ObtenireSectionAnalytiqueParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SectionAnalytiqueReponse>>> CreationAsync([FromBody] SectionAnalytiqueRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SectionAnalytiqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sectionanalytiqueBLL.CreationSectionAnalytique(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sectionanalytiqueid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sectionanalytiqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SectionAnalytiqueReponse>>> MisejourAsync(int sectionanalytiqueid, [FromBody] SectionAnalytiqueEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SectionAnalytiqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sectionanalytiqueBLL.MisejourSectionAnalytique(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sectionanalytiqueid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sectionanalytiqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SectionAnalytiqueReponse>>> SuppressionAsync(int sectionanalytiqueid)
		{
			var response = await _sectionanalytiqueBLL.SuppressionSectionAnalytique(sectionanalytiqueid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
