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
{	[Route("api/rotations")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class RotationController : ControllerBase
	{

		private readonly IRotationBLL _rotationBLL;
		private readonly ILogger<RotationController> _logger;
		public RotationController(IRotationBLL rotationBLL, ILogger<RotationController> logger)
		{
			_rotationBLL = rotationBLL ?? throw new ArgumentNullException(nameof(rotationBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<RotationListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _rotationBLL.ObtenireRotationListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id rotation</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<RotationReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _rotationBLL.ObtenireRotationParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<RotationReponse>>> CreationAsync([FromBody] RotationRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<RotationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _rotationBLL.CreationRotation(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="rotationid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{rotationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<RotationReponse>>> MisejourAsync(int rotationid, [FromBody] RotationEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<RotationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _rotationBLL.MisejourRotation(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="rotationid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{rotationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<RotationReponse>>> SuppressionAsync(int rotationid)
		{
			var response = await _rotationBLL.SuppressionRotation(rotationid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
