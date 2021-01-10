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
{	[Route("api/equipes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class EquipeController : ControllerBase
	{

		private readonly IEquipeBLL _equipeBLL;
		private readonly ILogger<EquipeController> _logger;
		public EquipeController(IEquipeBLL equipeBLL, ILogger<EquipeController> logger)
		{
			_equipeBLL = equipeBLL ?? throw new ArgumentNullException(nameof(equipeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<EquipeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _equipeBLL.ObtenireEquipeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id equipe</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<EquipeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _equipeBLL.ObtenireEquipeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<EquipeReponse>>> CreationAsync([FromBody] EquipeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _equipeBLL.CreationEquipe(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="equipeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{equipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EquipeReponse>>> MisejourAsync(int equipeid, [FromBody] EquipeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _equipeBLL.MisejourEquipe(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="equipeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{equipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EquipeReponse>>> SuppressionAsync(int equipeid)
		{
			var response = await _equipeBLL.SuppressionEquipe(equipeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
