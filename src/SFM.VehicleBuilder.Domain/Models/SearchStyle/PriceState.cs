using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A Enum class for PriceState.
    /// </summary>
    public enum PriceState
    {
        /// <summary>
        ///   Enum for the Actual.
        /// </summary>
        Actual,

        /// <summary>
        ///   Enum for the Estimated.
        /// </summary>
        Estimated,

        /// <summary>
        ///   Enum for the Unknown.
        /// </summary>
        Unknown,
    }
}
