using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.GetConfigByStyleQuery
{
    public class GetConfigByStyleQuery : SecureQueryBase<List<StyleConfigration>>
    {
        public GetConfigByStyleQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the StyleId.
        /// </summary>
        public int StyleId { get; set; }
    }
}