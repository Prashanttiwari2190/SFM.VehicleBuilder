using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;
using SFM.VehicleBuilder.Domain.Models;

namespace SFM.VehicleBuilder.Application.Queries.UXGetMakeQuery
{
    public class UXGetMakeQueryHandler : IRequestHandler<UXGetMakeQuery, IEnumerable<Division>>
    {
        private readonly IChromeDataService chromeDataService;

        public UXGetMakeQueryHandler(IChromeDataService chromeDataService)
        {
            this.chromeDataService = chromeDataService;
        }

        public async Task<IEnumerable<Division>> Handle(UXGetMakeQuery request, CancellationToken cancellationToken)
        {
            var divisions = (await chromeDataService.GetDivisions(request.Year)).Select(i =>
                          new Division
                          {
                              DivisionId = i.divisionId,
                              DivisionName = i.divisionName,
                          }).ToList();
            return divisions;
        }
    }
}