using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;

namespace SFM.VehicleBuilder.Application.Queries.SampleQuery
{
    public class SampleQueryHandler : IRequestHandler<SampleQuery, Unit>
    {
        private readonly AccountInfo accountInfo;

        public SampleQueryHandler(AccountInfo accountInfo)
        {
            this.accountInfo = accountInfo;
        }

        public async Task<Unit> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = new AutomotiveConfigCompareService4hPortTypeClient();

                var yearsReq = new getModelYearsRequest()
                {
                    ModelYearsRequest = new ModelYearsRequest
                    {
                        accountInfo = accountInfo,
                        filterRules = new FilterRules(),
                    },
                };

                var years = await client.getModelYearsAsync(yearsReq);

                var divisionsReq = new getDivisionsRequest()
                {
                    DivisionsRequest = new DivisionsRequest
                    {
                        accountInfo = accountInfo,
                        filterRules = new FilterRules { },
                        modelYear = 2020,
                    },
                };

                var divisions = await client.getDivisionsAsync(divisionsReq);

                var modelsReq = new getModelsByDivisionRequest()
                {
                    ModelsByDivisionRequest = new ModelsByDivisionRequest
                    {
                        accountInfo = accountInfo,
                        divisionId = 13,
                        modelYear = 2020,
                        filterRules = new FilterRules(),
                    },
                };

                var models = await client.getModelsByDivisionAsync(modelsReq);

                /*
                var yearsReq = new ChromeData.getDivisionsRequest()
                {
                    DivisionsRequest = new DivisionsRequest
                    {
                        accountInfo = accountInfo,
                    },
                };

                var years = await client.getModelYearsAsync(yearsReq);

                var yearsReq = new getModelsByDivisionRequest()
                {
                    ModelsByDivisionRequest = new ModelsByDivisionRequest
                    {
                        accountInfo = accountInfo,
                    },
                };

                var years = await client.getModelYearsAsync(yearsReq);

                var yearsReq = new getModelYearsRequest()
                {
                    ModelYearsRequest = new ModelYearsRequest
                    {
                        accountInfo = accountInfo,
                        filterRules = new FilterRules()
                        {
                        }
                    },
                };

                var years = await client.getModelYearsAsync(yearsReq);

                var req = new getCategoryDefinitionsRequest();

                req.CategoryDefinitionsRequest = new CategoryDefinitionsRequest
                {
                    accountInfo = accountInfo,
                };

                var response = await client.getCategoryDefinitionsAsync(req);
                */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return Unit.Value;
        }
    }
}