using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.ChromeData;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;

namespace SFM.VehicleBuilder.Application.Queries.UXGetModeByStylesQuery
{
    public class UXGetModeByStylesQueryHandler : IRequestHandler<UXGetModeByStylesQuery, ModelConfigration>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetModeByStylesQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<ModelConfigration> Handle(UXGetModeByStylesQuery request, CancellationToken cancellationToken)
        {
            var wheelbase = new List<WheelBase>();
            var genericColors = new List<GenericColors>();
            var modelConfigration = new ModelConfigration();
            var response = await chromeDataService.GetModelConfigurationByStyleIds(request.StyleIds);
            if (response != null)
            {
               var responseWheelbase = response.configuration.technicalSpecifications.Where(s => s.titleId == 301);
               var responsecolors = response.configuration.equipment.Where(s => s.headerName == "PRIMARY PAINT");

               if (responseWheelbase.Any())
                {
                foreach (var wheel in responseWheelbase)
                    {
                        var wheelobj = new WheelBase();
                        wheelobj.Value = wheel.values == null ? null : wheel.values.Select(j => j.value);
                        wheelbase.Add(wheelobj);
                    }

                modelConfigration.Wheelbase = wheelbase;
                }

               if (responsecolors.Any())
                {
                    foreach (var colors in responsecolors)
                    {
                        var colorobj = new GenericColors();
                        colorobj.Name = colors.genericColors.Select(k => k.name).ToArray();
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