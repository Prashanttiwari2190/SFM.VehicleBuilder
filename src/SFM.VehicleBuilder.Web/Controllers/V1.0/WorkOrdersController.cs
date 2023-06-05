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
    ///   A controller used to service Fleetio work orders.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Work Orders")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/work-orders")]
    public class WorkOrdersController : ControllerBase
    {
        private readonly ILogger<WorkOrdersController> logger;
        private readonly IMediator mediator;

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkOrdersController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of an <see cref="IMediator"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        public WorkOrdersController(
            IMediator mediator,
            ILogger<WorkOrdersController> logger)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        ///   Gets the status of a work order.
        /// </summary>
        /// <returns>Returns a <see cref="string"/> containg the status of the work order.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("")]
        public async Task<ActionResult<string>> GetWorkOrderPaymentStatus()
        {
            await this.Execute(logger, () => mediator.Send(new SampleQuery(new CorrelationId(Guid.NewGuid()))));

            /*=> this.Execute(logger, () => mediator.Send(new GetWorkOrderStatusQuery
            // { WorkOrderNumber = workOrderNumber, }));*/

            throw new NotImplementedException();
        }
    }
}