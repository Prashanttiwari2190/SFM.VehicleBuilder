using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.GetModelConfigByStylesQuery
{
    public class GetModelConfigByStylesQuery : SecureQueryBase<ModelConfigration>
    {
        public GetModelConfigByStylesQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the StyleIds.
        /// </summary>
        public int[] StyleIds { get; set; }
    }
}