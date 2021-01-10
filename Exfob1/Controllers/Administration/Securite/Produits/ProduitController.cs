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
{	[Route("api/produits")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ProduitController : ControllerBase
	{

		private readonly IProduitBLL _produitBLL;
		private readonly ILogger<ProduitController> _logger;
		public ProduitController(IProduitBLL produitBLL, ILogger<ProduitController> logger)
		{
			_produitBLL = produitBLL ?? throw new ArgumentNullException(nameof(produitBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ProduitListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _produitBLL.ObtenireProduitListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id produit</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ProduitReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _produitBLL.ObtenireProduitParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ProduitReponse>>> CreationAsync([FromBody] ProduitRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ProduitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _produitBLL.CreationProduit(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="produitid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{produitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ProduitReponse>>> MisejourAsync(int produitid, [FromBody] ProduitEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ProduitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _produitBLL.MisejourProduit(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="produitid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{produitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ProduitReponse>>> SuppressionAsync(int produitid)
		{
			var response = await _produitBLL.SuppressionProduit(produitid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
