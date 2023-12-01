using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetMakeQuery
{
    public class UXGetMakeQuery : SecureQueryBase<IEnumerable<Division>>
    {
        public UXGetMakeQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        public int Year { get; set; }
    }
}