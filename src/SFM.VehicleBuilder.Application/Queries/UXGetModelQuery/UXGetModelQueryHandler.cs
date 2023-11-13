using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;

namespace SFM.VehicleBuilder.Application.Queries.UXGetModelQuery
{
    public class UXGetModelQueryHandler : IRequestHandler<UXGetModelQuery, IEnumerable<Model>>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetModelQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<IEnumerable<Model>> Handle(UXGetModelQuery request, CancellationToken cancellationToken)
        {
            var models = await chromeDataService.GetModels(request.Year, request.Division);
            return models;
        }
    }
}