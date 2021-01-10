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
{	[Route("api/fournisseurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class FournisseurController : ControllerBase
	{

		private readonly IFournisseurBLL _fournisseurBLL;
		private readonly ILogger<FournisseurController> _logger;
		public FournisseurController(IFournisseurBLL fournisseurBLL, ILogger<FournisseurController> logger)
		{
			_fournisseurBLL = fournisseurBLL ?? throw new ArgumentNullException(nameof(fournisseurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<FournisseurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _fournisseurBLL.ObtenireFournisseurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id fournisseur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<FournisseurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _fournisseurBLL.ObtenireFournisseurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<FournisseurReponse>>> CreationAsync([FromBody] FournisseurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<FournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _fournisseurBLL.CreationFournisseur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="fournisseurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{fournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<FournisseurReponse>>> MisejourAsync(int fournisseurid, [FromBody] FournisseurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<FournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _fournisseurBLL.MisejourFournisseur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="fournisseurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{fournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<FournisseurReponse>>> SuppressionAsync(int fournisseurid)
		{
			var response = await _fournisseurBLL.SuppressionFournisseur(fournisseurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
