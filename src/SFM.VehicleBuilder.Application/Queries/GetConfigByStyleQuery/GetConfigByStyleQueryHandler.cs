using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Intuit.Ipp.Data;
using MediatR;
using Microsoft.Extensions.Options;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;

namespace SFM.VehicleBuilder.Application.Queries.GetConfigByStyleQuery
{
    public class GetConfigByStyleQueryHandler : IRequestHandler<GetConfigByStyleQuery, List<StyleConfigration>>
    {
        private readonly IChromeDataService chromeDataService;

        public GetConfigByStyleQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<List<StyleConfigration>> Handle(GetConfigByStyleQuery request, CancellationToken cancellationToken)
        {
            var styleConfigration = new StyleConfigration();
            var liststyleConfigration = new List<StyleConfigration>();
            var response = await chromeDataService.GetConfigurationByStyleId(request.StyleId);
            if (response != null)
            {
                // BASE PRICE
                if (response.configuration.style != null)
                {
                    styleConfigration = new StyleConfigration();
                    var equipmentOption = new EquipmentOption();
                    styleConfigration.CategoryName = "BASE PRICE";
                    equipmentOption.MSRP = Convert.ToDecimal(response.configuration.style.baseMsrp);
                    equipmentOption.Invoice = Convert.ToDecimal(response.configuration.style.baseInvoice);
                    equipmentOption.Code = response.configuration.style.manufacturerModelCode;
                    equipmentOption.Description = new string[1];
                    equipmentOption.Description[0] = response.configuration.style.styleName;
                    styleConfigration.EquipmentOptions = new List<EquipmentOption> { equipmentOption };
                    liststyleConfigration.Add(styleConfigration);
                }

                // EXTERIOR COLOR
                var responseExteriorColour = response.configuration.options.Where(s => s.headerName == "PRIMARY PAINT");
                if (responseExteriorColour != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "EXTERIOR COLOR";
                    styleConfigration.EquipmentOptions = responseExteriorColour.Select(responseExteriorColour => new EquipmentOption
                    {
                        Code = responseExteriorColour.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseExteriorColour.msrp),
                        Invoice = Convert.ToDecimal(responseExteriorColour.invoice),
                        Description = responseExteriorColour.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // OPTION PACKAGE
                var responseOptionPackage = response.configuration.options.Where(s => s.headerName == "OPTION PACKAGE");
                if (responseOptionPackage != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "OPTION PACKAGE";
                    styleConfigration.EquipmentOptions = responseOptionPackage.Select(responseOptionPackage => new EquipmentOption
                    {
                        Code = responseOptionPackage.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseOptionPackage.msrp),
                        Invoice = Convert.ToDecimal(responseOptionPackage.invoice),
                        Description = responseOptionPackage.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // ENGINE
                var responseEngine = response.configuration.options.Where(s => s.headerName == "ENGINE");
                if (responseEngine != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "ENGINE";
                    styleConfigration.EquipmentOptions = responseEngine.Select(responseEngine => new EquipmentOption
                    {
                        Code = responseEngine.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseEngine.msrp),
                        Invoice = Convert.ToDecimal(responseEngine.invoice),
                        Description = responseEngine.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // TIRES
                var responseTires = response.configuration.options.Where(s => s.headerName == "TIRES");
                if (responseTires != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "TIRES";
                    styleConfigration.EquipmentOptions = responseTires.Select(responseTires => new EquipmentOption
                    {
                        Code = responseTires.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseTires.msrp),
                        Invoice = Convert.ToDecimal(responseTires.invoice),
                        Description = responseTires.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // WHEELS
                var responseWheels = response.configuration.options.Where(s => s.headerName == "WHEELS");
                if (responseWheels != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "WHEELS";
                    styleConfigration.EquipmentOptions = responseWheels.Select(responseWheels => new EquipmentOption
                    {
                        Code = responseWheels.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseWheels.msrp),
                        Invoice = Convert.ToDecimal(responseWheels.invoice),
                        Description = responseWheels.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // SEAT TYPE
                var responseSeatType = response.configuration.options.Where(s => s.headerName == "SEAT TYPE");
                if (responseSeatType != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "SEAT TYPE";
                    styleConfigration.EquipmentOptions = responseSeatType.Select(responseSeatType => new EquipmentOption
                    {
                        Code = responseSeatType.oemOptionCode,
                        MSRP = Convert.ToDecimal(responseSeatType.msrp),
                        Invoice = Convert.ToDecimal(responseSeatType.invoice),
                        Description = responseSeatType.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // DEALER INSTALLED OPTIONS
                var responseDealerOptions = response.configuration.options.Where(s => s.headerName == "DEALER INSTALLED OPTIONS");
                if (responseDealerOptions != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "DEALER INSTALLED OPTIONS";
                    styleConfigration.EquipmentOptions = responseDealerOptions.Select(responseDealerOptions => new EquipmentOption
                    {
                        Code = responseDealerOptions.chromeOptionCode,
                        MSRP = Convert.ToDecimal(responseDealerOptions.msrp),
                        Invoice = Convert.ToDecimal(responseDealerOptions.invoice),
                        Description = responseDealerOptions.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }

                // ADDITIONAL EQUIPMENT
                var responseAdditionalEquipment = response.configuration.options.Where(s => s.headerName == "ADDITIONAL EQUIPMENT");
                if (responseAdditionalEquipment != null)
                {
                    styleConfigration = new StyleConfigration();
                    styleConfigration.CategoryName = "OTHER OPTIONS";
                    styleConfigration.EquipmentOptions = responseAdditionalEquipment.Select(responseAdditionalEquipment => new EquipmentOption
                    {
                        Code = responseAdditionalEquipment.chromeOptionCode,
                        MSRP = Convert.ToDecimal(responseAdditionalEquipment.msrp),
                        Invoice = Convert.ToDecimal(responseAdditionalEquipment.invoice),
                        Description = responseAdditionalEquipment.descriptions.Select(desc => desc.description).ToArray(),
                    }).ToList();
                    liststyleConfigration.Add(styleConfigration);
                }
            }

            return liststyleConfigration;
        }
    }
}