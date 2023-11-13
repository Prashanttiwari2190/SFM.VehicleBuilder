using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;

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
            var models = (await chromeDataService.GetModels(request.Year, request.Division)).Select(i =>
                        new Model
                        {
                            ModelId = i.modelId,
                            ModelName = i.modelName,
                        }).ToList();
            return models;
        }
    }
}