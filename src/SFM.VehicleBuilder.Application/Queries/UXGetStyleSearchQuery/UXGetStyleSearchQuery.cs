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

        /// <summary>
        ///   Gets or sets the ExteriorColorId.
        /// </summary>
        public string ExteriorColorId { get; set; }

        /// <summary>
        ///   Gets or sets the CabStyleId.
        /// </summary>
        public string CabStyleId { get; set; }

        /// <summary>
        ///   Gets or sets the MinWheelBase.
        /// </summary>
        public string MinWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MaxWheelBase.
        /// </summary>
        public string MaxWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MinPriceLevel.
        /// </summary>
        public string MinPriceLevel { get; set; }

        /// <summary>
        ///   Gets or sets the MaxPriceLevel.
        /// </summary>
        public string MaxPriceLevel { get; set; }
    }
}