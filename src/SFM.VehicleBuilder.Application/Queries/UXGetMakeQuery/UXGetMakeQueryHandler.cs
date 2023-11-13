using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Data.Services.ChromeData;

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
            var divisions = await chromeDataService.GetDivisions(request.Year);
            return divisions;
        }
    }
}