using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetYearQuery
{
    public class UXGetStyleSearchQuery : SecureQueryBase<IEnumerable<Styles>>
    {
        public UXGetStyleSearchQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the Year.
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        ///   Gets or sets the DivisonId.
        /// </summary>
        public string DivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public string ModelId { get; set; }
    }
}