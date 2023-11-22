using ChromeData;
using SFM.VehicleBuilder.Domain.Models.SearchStyle;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Data.Services.ChromeData
{
    /// <inheritdoc/>
    public class ChromeDataService : IChromeDataService
    {
        private readonly AccountInfo accountInfo;
        private readonly AutomotiveConfigCompareService4hPortTypeClient client;

        public ChromeDataService(AccountInfo accountInfo)
        {
            this.accountInfo = accountInfo;
            this.client = new AutomotiveConfigCompareService4hPortTypeClient();
        }

        public async Task<int[]> GetModelYears()
        {
            var yearsReq = new getModelYearsRequest()
            {
                ModelYearsRequest = new ModelYearsRequest
                {
                    accountInfo = accountInfo,
                    filterRules = new FilterRules(),
                },
            };
            var yearsRes = await client.getModelYearsAsync(yearsReq);
            return yearsRes.IntArrayElement;
        }

        public async Task<IEnumerable<Division>> GetDivisions(int modelYear)
        {
            var divisionReq = new getDivisionsRequest()
            {
                DivisionsRequest = new DivisionsRequest
                {
                    accountInfo = accountInfo,
                    filterRules = new FilterRules(),
                    modelYear = modelYear,
                },
            };
            var divisionsRes = await client.getDivisionsAsync(divisionReq);
            return divisionsRes.DivisionArrayElement;
        }

        public async Task<IEnumerable<Model>> GetModels(int modelYear, int divisionId)
        {
            var modelReq = new getModelsByDivisionRequest()
            {
                ModelsByDivisionRequest = new ModelsByDivisionRequest
                {
                    accountInfo = accountInfo,
                    filterRules = new FilterRules(),
                    modelYear = modelYear,
                    divisionId = divisionId,
                },
            };
            var modelRes = await client.getModelsByDivisionAsync(modelReq);
            return modelRes.ModelArrayElement;
        }

        public async Task<IEnumerable<Style>> GetStyles(StyleFilter styleFilter)
        {
            var criteriaList = new List<SearchCriterion>
            {
                new SearchCriterion() // Search By Year
                {
                    name = SearchTokenName.year,
                    type = SearchCriterionType.NumberRange,
                    min = styleFilter.Year,
                    max = styleFilter.Year,
                },
                new SearchCriterion() // Search By Divison Id
                {
                    name = SearchTokenName.divisionId,
                    type = SearchCriterionType.String,
                    value = styleFilter.DivisionId,
                },
                new SearchCriterion() // Search By Model Id
                {
                    name = SearchTokenName.model,
                    type = SearchCriterionType.String,
                    value = styleFilter.ModelId,
                },
                new SearchCriterion() // Search ByExteriorColor
                {
                    name = SearchTokenName.primaryExteriorColor,
                    type = SearchCriterionType.String,
                    value = styleFilter.ExteriorColorId,
                },
                new SearchCriterion() // Search By CabStyleId
                {
                    name = SearchTokenName.styleId,
                    type = SearchCriterionType.String,
                    value = styleFilter.CabStyleId,
                },

                new SearchCriterion() // Search By wheelbase
                 {
                    name = SearchTokenName.wheelbase,
                    type = SearchCriterionType.TechnicalSpecificationRange,
                    min = styleFilter.MinWheelBase,
                    max = styleFilter.MaxWheelBase,
                 },
                new SearchCriterion() // Search By msrp
                 {
                    name = SearchTokenName.msrp,
                    type = SearchCriterionType.MoneyRange,
                    min = styleFilter.MinPriceLevel,
                    max = styleFilter.MaxPriceLevel,
                 },
            };

            var styleReq = new searchStylesRequest1()
            {
                SearchStylesRequest = new SearchStylesRequest()
                {
                    accountInfo = accountInfo,
                    searchRequest = new SearchServiceRequest()
                    {
                        criteriaArray = criteriaList.ToArray(),
                        maxNumResults = 20,
                    },
                },
            };
            var styleRes = await client.searchStylesAsync(styleReq);
            return styleRes.StyleArrayElement;
        }
    }
}
