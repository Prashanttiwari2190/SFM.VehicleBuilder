using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;
using SFM.VehicleBuilder.Domain.Models.ChromeData;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;

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
                             StartingAtMsrpField = i.startingAtMsrp,
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
                             Model = i.model == null ? null : new SearchStyleModel
                             {
                                 ModelYear = i.model.modelYear,
                                 DivisionId = i.model.divisionId,
                                 DivisionName = i.model.divisionName,
                                 SubdivisionId = i.model.subdivisionId,
                                 SubdivisionName = i.model.subdivisionName,
                                 ModelId = i.model.modelId,
                                 ModelName = i.model.modelName,
                                 DataReleaseDate = i.model.dataReleaseDate,
                                 InitialPriceDate = i.model.initialPriceDate,
                                 DataEffectiveDate = i.model.dataEffectiveDate,
                                 DataComment = i.model.dataComment,
                             },
                             BodyTypes = i.bodyTypes.Select(g => new SearchStyleBodyType
                             {
                                 BodyTypeId = g.bodyTypeId,
                                 BodyTypeName = g.bodyTypeName,
                                 Primary = g.primary,
                             }).ToArray(),
                         }).ToList();
        }
    }
}