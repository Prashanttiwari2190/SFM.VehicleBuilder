using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;

namespace SFM.VehicleBuilder.Application.Queries.SampleQuery
{
    public class SampleQueryHandler : IRequestHandler<SampleQuery, int[]>
    {
        private readonly IChromeDataService service;

        public SampleQueryHandler(IChromeDataService service)
        {
            this.service = service;
        }

        public async Task<int[]> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await service.GetModelYears();
            }
            catch (Exception ex)
            {
                // Instead throw custom exception
                Debug.WriteLine(ex.ToString());
                throw new NotImplementedException();
            }
        }
    }
}