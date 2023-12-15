using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetModeByStylesQuery
{
    public class UXGetModeByStylesQuery : SecureQueryBase<ModelConfigration>
    {
        public UXGetModeByStylesQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the StyleIds.
        /// </summary>
        public int[] StyleIds { get; set; }
    }
}