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

namespace SFM.VehicleBuilder.Application.Queries.UXGetStylesQuery
{
    public class UXGetStylesQueryHandler : IRequestHandler<UXGetStylesQuery, IEnumerable<Styles>>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetStylesQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<IEnumerable<Styles>> Handle(UXGetStylesQuery request, CancellationToken cancellationToken)
        {
                return (await chromeDataService.GetStyles(request.ModelId)).Select(i =>
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
                             PriceState = i.priceState.ToString(),
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
                             EnhancedBasePrices = i.enhancedBasePrices == null ? null : i.enhancedBasePrices.Select(g => new EnhancedPrice
                             {
                                 Price = g.price,
                                 Masked = g.masked,
                                 PriceLevel = g.priceLevel == null ? null : new EnhancedPriceLevel
                                 {
                                     Id = g.priceLevel.id,
                                     Description = g.priceLevel.description,
                                     ShortDescription = g.priceLevel.shortDescription,
                                 },

                                 PriceState = g.priceState.ToString(),
                             }).ToArray(),
                             BodyTypes = i.bodyTypes == null ? null : i.bodyTypes.Select(g => new SearchStyleBodyType
                             {
                                 BodyTypeId = g.bodyTypeId,
                                 BodyTypeName = g.bodyTypeName,
                                 Primary = g.primary,
                             }).ToArray(),
                             ConfigurationStateField = i.configurationState == null ? null : new ConfigurationState
                             {
                                 DataVersionField = i.configurationState.dataVersion,
                                 StyleIdField = i.configurationState.styleId,
                                 FullyConfiguredField = i.configurationState.fullyConfigured,
                                 OrderAvailabilityField = i.configurationState.orderAvailability.ToString(),
                                 SpecialEquipmentEnabledField = i.configurationState.specialEquipmentEnabled,
                                 OptionOrderLogicDisabledField = i.configurationState.optionOrderLogicDisabled,
                                 InitialPricingEnabledField = i.configurationState.initialPricingEnabled,
                                 ChromeOptionCodeToggleStreamField = i.configurationState.chromeOptionCodeToggleStream,
                                 SelectedChromeOptionCodesField = i.configurationState.selectedChromeOptionCodes,
                                 SerializedValueField = i.configurationState.serializedValue,
                                 ConditionPropertiesField = i.configurationState.conditionProperties == null ? null : i.configurationState.conditionProperties.Select(k => new ConditionProperty
                                 {
                                     NameField = k.name,
                                     ValueField = k.name,
                                 }).ToArray(),
                                 ConstraintField = i.configurationState.constraint == null ? null : new ConfigurationConstraint
                                 {
                                     ConstraintIdField = i.configurationState.constraint.constraintId,
                                     ConstraintNameField = i.configurationState.constraint.constraintName,
                                     AvailableOptionsField = i.configurationState.constraint.availableOptions,
                                     PreselectedOptionsField = i.configurationState.constraint.preselectedOptions,
                                 },
                                 UserDefinedTechSpecsField = i.configurationState.userDefinedTechSpecs == null ? null : new UserDefinedTechSpecs
                                 {
                                     RoadSurfaceField = i.configurationState.userDefinedTechSpecs.roadSurface.ToString(),
                                     RoadGradeField = i.configurationState.userDefinedTechSpecs.roadGrade,
                                     OccupantWeightField = i.configurationState.userDefinedTechSpecs.occupantWeight,
                                     BodyLengthField = i.configurationState.userDefinedTechSpecs.bodyLength,
                                     BodyFrontalAreaField = i.configurationState.userDefinedTechSpecs.bodyFrontalArea,
                                     BodyWeightField = i.configurationState.userDefinedTechSpecs.bodyWeight,
                                     CabToBodyDistanceField = i.configurationState.userDefinedTechSpecs.trailerWeight,
                                     TrailerWeightField = i.configurationState.userDefinedTechSpecs.cabToBodyDistance,
                                     CargoItemsField = i.configurationState.userDefinedTechSpecs.cargoItems == null ? null : i.configurationState.userDefinedTechSpecs.cargoItems.Select(k => new CargoItem
                                     {
                                         ItemNameField = k.itemName,
                                         LiquidCargoField = k.liquidCargo,
                                         CargoWeightField = k.cargoWeight,
                                         DistanceFromRearAxleField = k.distanceFromRearAxle,
                                     }).ToArray(),

                                     BodyTypeField = i.configurationState.userDefinedTechSpecs.bodyType.ToString(),
                                     MeasurementSystemField = i.configurationState.userDefinedTechSpecs.measurementSystem.ToString(),
                                 },
                             },
                         }).ToList();
        }
    }
}