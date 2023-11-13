﻿using ChromeData;
using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetMakeQuery
{
    public class UXGetMakeQuery : QueryBase<IEnumerable<Division>>
    {
        public UXGetMakeQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        public int Year { get; set; }
    }
}