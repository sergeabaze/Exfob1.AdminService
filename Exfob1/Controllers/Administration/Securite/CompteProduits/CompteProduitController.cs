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
{	[Route("api/compteproduits")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class CompteProduitController : ControllerBase
	{

		private readonly ICompteProduitBLL _compteproduitBLL;
		private readonly ILogger<CompteProduitController> _logger;
		public CompteProduitController(ICompteProduitBLL compteproduitBLL, ILogger<CompteProduitController> logger)
		{
			_compteproduitBLL = compteproduitBLL ?? throw new ArgumentNullException(nameof(compteproduitBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<CompteProduitListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _compteproduitBLL.ObtenireCompteProduitListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id compteproduit</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<CompteProduitReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _compteproduitBLL.ObtenireCompteProduitParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<CompteProduitReponse>>> CreationAsync([FromBody] CompteProduitRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CompteProduitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _compteproduitBLL.CreationCompteProduit(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="compteproduitid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{compteproduitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CompteProduitReponse>>> MisejourAsync(int compteproduitid, [FromBody] CompteProduitEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CompteProduitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _compteproduitBLL.MisejourCompteProduit(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="compteproduitid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{compteproduitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CompteProduitReponse>>> SuppressionAsync(int compteproduitid)
		{
			var response = await _compteproduitBLL.SuppressionCompteProduit(compteproduitid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
