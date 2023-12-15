using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetStylesQuery
{
    public class UXGetStylesQuery : SecureQueryBase<IEnumerable<Styles>>
    {
        public UXGetStylesQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public int ModelId { get; set; }
    }
}