using ChromeData;
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
    }
}
