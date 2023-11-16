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
            var styleOption = await FileExtension.FileRead();
            return styleOption;
        }
    }
}