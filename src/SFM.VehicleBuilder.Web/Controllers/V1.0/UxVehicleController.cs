using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFM.VehicleBuilder.Application.Queries.SampleQuery;
using SFM.VehicleBuilder.Application.Queries.UXGetMakeQuery;
using SFM.VehicleBuilder.Application.Queries.UXGetModelQuery;
using SFM.VehicleBuilder.Application.Queries.UXGetStyleOptionsQuery;
using SFM.VehicleBuilder.Application.Queries.UXGetYearQuery;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;

namespace SFM.VehicleBuilder.Web.Controllers.V1
{
    /// <summary>
    ///   A controller used to service Fleetio work orders.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Vehicle")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/vehicle")]
    public class UxVehicleController : ControllerBase
    {
        private readonly ILogger<UxVehicleController> logger;
        private readonly IMediator mediator;
        private readonly CorrelationId correlationId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="UxVehicleController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of an <see cref="IMediator"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/>The correlation ID used to track requests through the system.</param>
        public UxVehicleController(
            IMediator mediator,
            ILogger<UxVehicleController> logger,
            CorrelationId correlationId)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.correlationId = correlationId;
        }

        /// <summary>
        ///    Gets the Make list.
        /// </summary>
        /// <param name="year">year information.</param>
        /// <returns>Returns a <see cref="string"/> containg the status of the division.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("make/{year}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Division>>> GetMake([FromRoute] int year)
        {
            var query = new UXGetMakeQuery(correlationId)
            {
                Year = year,
            };

            return await this.Execute(logger, () => mediator.Send(query, CancellationToken.None));
        }

        /// <summary>
        ///    Gets the Year list.
        /// </summary>
        /// <returns>Returns a containg the list of the year.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("year")]
        [Authorize]
        public async Task<ActionResult<int[]>> GetYear()
         => await this.Execute(logger, () => mediator.Send(new UXGetYearQuery(correlationId), CancellationToken.None));

        /// <summary>
        ///   Gets the model list.
        /// </summary>
        /// <param name="year"> year information.</param>
        /// <param name="division"> division information.</param>
        /// <returns>Returns a <see cref="string"/> containg the status of the model.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("{year}/model/{division}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Model>>> GetModel([FromRoute] int year, [FromRoute] int division)
        {
            var query = new UXGetModelQuery(correlationId)
            {
                Year = year,
                Division = division,
            };

            return await this.Execute(logger, () => mediator.Send(query, CancellationToken.None));
        }

        /// <summary>
        ///   Gets the CabStyleOptions.
        /// </summary>
        /// <returns>Returns a <see cref="string"/> containg the status of the work order.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("style-options")]
        [Authorize]
        public async Task<ActionResult<StyleOptions>> CabStyleOption() => await this.Execute(logger, () => mediator.Send(new UXGetStyleOptionsQuery(correlationId), CancellationToken.None));

        /// <summary>
        ///   Gets the GetWheelbase list.
        /// </summary>
        /// <returns>Returns a <see cref="string"/> containg the status of the work order.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("")]
        [Authorize]
        public async Task<ActionResult<string>> GetWheelbase()
        {
            await this.Execute(logger, () => mediator.Send(new SampleQuery(new CorrelationId(Guid.NewGuid()))));

            /*=> this.Execute(logger, () => mediator.Send(new GetWorkOrderStatusQuery
            // { WorkOrderNumber = workOrderNumber, }));*/

            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the GetPriceLevel list.
        /// </summary>
        /// <returns>Returns a <see cref="string"/> containg the status of the work order.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("")]
        [Authorize]
        public async Task<ActionResult<string>> GetPriceLevel()
        {
            await this.Execute(logger, () => mediator.Send(new SampleQuery(new CorrelationId(Guid.NewGuid()))));

            /*=> this.Execute(logger, () => mediator.Send(new GetWorkOrderStatusQuery
            // { WorkOrderNumber = workOrderNumber, }));*/

            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the StyleSearch list.
        /// </summary>
        /// <param name="styleFilterParameter"> division information.</param>
        /// <returns>Returns a <see cref="string"/> containg the status of the work order.</returns>
        [HttpPost("style-search")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Styles>>> StyleSearch([FromBody] StyleFilterParameters styleFilterParameter)
        {
            var query = new UXGetStyleSearchQuery(correlationId)
            {
                Year = Convert.ToString(styleFilterParameter.Year),
                DivisionId = Convert.ToString(styleFilterParameter.DivisionId),
                ModelId = Convert.ToString(styleFilterParameter.ModelId),
                ExteriorColorId = Convert.ToString(styleFilterParameter.ExteriorColorId),
                CabStyleId = Convert.ToString(styleFilterParameter.CabStyleId),
                MinWheelBase = Convert.ToString(styleFilterParameter.MinWheelBase * 0.9m),
                MaxWheelBase = Convert.ToString(styleFilterParameter.MaxWheelBase * 1.1m),
                MinPriceLevel = Convert.ToString(styleFilterParameter.MinPriceLevel),
                MaxPriceLevel = Convert.ToString(styleFilterParameter.MaxPriceLevel),
            };

            return await this.Execute(logger, () => mediator.Send(query, CancellationToken.None));
        }
    }
}