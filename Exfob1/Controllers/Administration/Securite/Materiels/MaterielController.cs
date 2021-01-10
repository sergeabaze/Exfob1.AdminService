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
{	[Route("api/materiels")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class MaterielController : ControllerBase
	{

		private readonly IMaterielBLL _materielBLL;
		private readonly ILogger<MaterielController> _logger;
		public MaterielController(IMaterielBLL materielBLL, ILogger<MaterielController> logger)
		{
			_materielBLL = materielBLL ?? throw new ArgumentNullException(nameof(materielBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<MaterielListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _materielBLL.ObtenireMaterielListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id materiel</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<MaterielReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _materielBLL.ObtenireMaterielParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<MaterielReponse>>> CreationAsync([FromBody] MaterielRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MaterielReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _materielBLL.CreationMateriel(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="materielid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{materielid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MaterielReponse>>> MisejourAsync(int materielid, [FromBody] MaterielEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MaterielReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _materielBLL.MisejourMateriel(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="materielid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{materielid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MaterielReponse>>> SuppressionAsync(int materielid)
		{
			var response = await _materielBLL.SuppressionMateriel(materielid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
