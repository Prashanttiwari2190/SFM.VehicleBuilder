using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using DocumentFormat.OpenXml.Spreadsheet;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.ChromeData;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;

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
               wheelbase = responseWheelbase.SelectMany(s => s.values.Select(v => new WheelBase { Value = v.value })).ToList();
               modelConfigration.Wheelbase = wheelbase;
               if (responsecolors.Any())
                {
                    foreach (var colors in responsecolors)
                    {
                        var colorobj = new GenericColors();
                        colorobj.Name = colors.genericColors.Select(i => i.name).First();
                        colorobj.RgbValue = colors.rgbValue;
                        genericColors.Add(colorobj);
                    }

                    modelConfigration.GenericColors = genericColors;
                }
            }

            return modelConfigration;
        }
    }
}