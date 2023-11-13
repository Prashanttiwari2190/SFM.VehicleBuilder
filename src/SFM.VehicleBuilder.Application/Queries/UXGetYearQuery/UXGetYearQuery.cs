using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;

namespace SFM.VehicleBuilder.Application.Queries.UXGetYearQuery
{
    public class UXGetYearQuery : QueryBase<int[]>
    {
        public UXGetYearQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }
    }
}