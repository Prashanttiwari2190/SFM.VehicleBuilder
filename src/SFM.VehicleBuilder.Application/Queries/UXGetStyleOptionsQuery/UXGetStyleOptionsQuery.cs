using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;

namespace SFM.VehicleBuilder.Application.Queries.UXGetStyleOptionsQuery
{
    public class UXGetStyleOptionsQuery : SecureQueryBase<StyleOptions>
    {
        public UXGetStyleOptionsQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }
    }
}