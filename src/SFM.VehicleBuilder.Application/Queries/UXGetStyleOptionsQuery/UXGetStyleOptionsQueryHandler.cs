using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            var styleOption = new StyleOptions();

            var filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filepath = filepath + @"\ChromeData\chromeDataStatic.json";

            // Let's load some JSON files asynchronously ...
            await using FileStream stream = File.OpenRead(filepath);
            styleOption = await JsonSerializer.DeserializeAsync<StyleOptions>(stream);
            return styleOption;
        }
    }
}