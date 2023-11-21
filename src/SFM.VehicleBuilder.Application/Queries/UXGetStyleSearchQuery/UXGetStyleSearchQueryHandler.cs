using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models.ChromeData;
using Style = SFM.VehicleBuilder.Domain.Models.ChromeData.Styles;

namespace SFM.VehicleBuilder.Application.Queries.UXGetYearQuery
{
    public class UXGetStyleSearchQueryHandler : IRequestHandler<UXGetStyleSearchQuery, IEnumerable<Styles>>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetStyleSearchQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<IEnumerable<Styles>> Handle(UXGetStyleSearchQuery request, CancellationToken cancellationToken)
        {
            var styleFilter = new StyleFilter();
            styleFilter.Year = request.Year;
            styleFilter.ModelId = request.ModelId;
            styleFilter.DivisionId = request.DivisionId;
            styleFilter.MaxPriceLevel = request.MaxPriceLevel;
            styleFilter.MinPriceLevel = request.MinPriceLevel;
            styleFilter.MinWheelBase = request.MinWheelBase;
            styleFilter.MaxWheelBase = request.MaxWheelBase;
            styleFilter.CabStyleId = request.CabStyleId;
            styleFilter.ExteriorColorId = request.ExteriorColorId;

            return (await chromeDataService.GetStyles(styleFilter)).Select(i =>
                         new Styles
                         {
                             StyleId = i.styleId,
                             StyleName = i.styleName,
                             StyleNameWithoutTrim = i.styleNameWithoutTrim,
                             TrimName = i.trimName,
                             ManufacturerModelCode = i.manufacturerModelCode,
                             StyleGroupStyleIds = i.styleGroupStyleIds,
                             StyleGroupBase = i.styleGroupBase,
                             BaseMsrp = i.baseMsrp,
                             BaseInvoice = i.baseInvoice,
                             StartingAtInvoice = i.startingAtInvoice,
                             StartingAtInvoiceSpecified = i.startingAtInvoiceSpecified,
                             StartingAtMsrp = i.startingAtMsrp,
                             StartingAtMsrpSpecified = i.startingAtMsrpSpecified,
                             Destination = i.destination,
                             TrueBasePrice = i.trueBasePrice,
                             PassengerDoors = i.passengerDoors,
                             MarketClassId = i.marketClassId,
                             MarketClassName = i.marketClassName,
                             AllocationGroup = i.allocationGroup,
                             StockPhotoUrl = i.stockPhotoUrl,
                             ConsumerFriendlyModelName = i.consumerFriendlyModelName,
                             ConsumerFriendlyStyleName = i.consumerFriendlyStyleName,
                             ConsumerFriendlyDrivetrain = i.consumerFriendlyDrivetrain,
                             ConsumerFriendlyBodyType = i.consumerFriendlyBodyType,
                             MarketingCopy = i.marketingCopy,
                         }).ToList();
        }
    }
}