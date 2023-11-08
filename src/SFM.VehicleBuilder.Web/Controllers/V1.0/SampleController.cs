using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFM.VehicleBuilder.Application.Queries.SampleQuery;
using SFM.VehicleBuilder.Domain.Correlation;

namespace SFM.VehicleBuilder.Web.Controllers.V1
{
    /// <summary>
    ///   A controller used to service Chrome Data sample.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Sample Data")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/sample-data")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> logger;
        private readonly IMediator mediator;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SampleController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of an <see cref="IMediator"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        public SampleController(
            IMediator mediator,
            ILogger<SampleController> logger)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        ///   Gets the status of a chrome data api.
        /// </summary>
        /// <returns>Returns a sample from chrome data api.</returns>
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("")]
        public async Task<ActionResult<int[]>> GetSampleData()
        {
            return await this.Execute(logger, () => mediator.Send(new SampleQuery(new CorrelationId(Guid.NewGuid()))));
        }
    }
}