using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.VehicleBuilder.Application.Extensions;
using SFM.VehicleBuilder.Domain.Models;

namespace SFM.VehicleBuilder.Application.Queries.UXGetStyleOptionsQuery
{
    public class UXGetStyleOptionsQueryHandler : IRequestHandler<UXGetStyleOptionsQuery, StyleOptions>
    {
        public UXGetStyleOptionsQueryHandler()
        {
        }

        public async Task<StyleOptions> Handle(UXGetStyleOptionsQuery request, CancellationToken cancellationToken)
        {
            var filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filepath = filepath + @"\ChromeData\chromeDataStatic.json";
            var styleOption = await filepath.ReadJsonFileAsModel<StyleOptions>();
            return styleOption;
        }
    }
}