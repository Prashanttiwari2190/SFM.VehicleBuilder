using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;

namespace SFM.VehicleBuilder.Application.Queries.UXGetYearQuery
{
    public class UXGetYearQueryHandler : IRequestHandler<UXGetYearQuery, int[]>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetYearQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<int[]> Handle(UXGetYearQuery request, CancellationToken cancellationToken)
        {
            var modelYears = await chromeDataService.GetModelYears();
            return modelYears;
        }
    }
}