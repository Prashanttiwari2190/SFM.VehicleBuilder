using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle divison.
    /// </summary>
    public class EnhancedPrice
    {
        /// <summary>
        ///   Gets or sets the Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the Masked.
        /// </summary>
        public bool Masked { get; set; }

        /// <summary>
        ///   Gets or sets the PriceState.
        /// </summary>
        public string PriceState { get; set; }

        /// <summary>
        ///   Gets or sets the PriceLevel.
        /// </summary>
        public EnhancedPriceLevel PriceLevel { get; set; }
    }
}
