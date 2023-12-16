using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;

namespace SFM.VehicleBuilder.Application.Queries.GetModelConfigByStylesQuery
{
    public class GetModelConfigByStylesQueryHandler : IRequestHandler<GetModelConfigByStylesQuery, ModelConfigration>
    {
        private readonly IChromeDataService chromeDataService;

        public GetModelConfigByStylesQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<ModelConfigration> Handle(GetModelConfigByStylesQuery request, CancellationToken cancellationToken)
        {
            var wheelbase = new List<WheelBase>();
            var genericColors = new List<GenericColors>();
            var modelConfigration = new ModelConfigration();
            var response = await chromeDataService.GetModelConfigurationByStyleIds(request.StyleIds);
            if (response != null)
            {
                var responseWheelbase = response.configuration.technicalSpecifications.Where(s => s.titleId == 301);
                var responsecolors = response.configuration.equipment.Where(s => s.headerName == "PRIMARY PAINT");
                modelConfigration.Wheelbase = responseWheelbase.SelectMany(s => s.values.Select(v =>
                  new WheelBase
                  {
                      StyleIds = v.availableStyleIds,
                      Value = v.value,
                  })).OrderBy(x => x.Value).ToList();
                modelConfigration.GenericColors = responsecolors.SelectMany(s => s.genericColors.Select(v =>
                  new GenericColors
                  {
                      StyleIds = s.availableStyleIds,
                      Name = v.name,
                      RgbValue = s.rgbValue,
                  })).ToList();
            }

            return modelConfigration;
        }
    }
}