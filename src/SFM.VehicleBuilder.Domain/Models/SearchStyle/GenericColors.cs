using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle GenericColors.
    /// </summary>
    public class GenericColors
    {
        /// <summary>
        ///   Gets or sets a chrome data StyleIds Available.
        /// </summary>
        public int[] StyleIds { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets a chrome data Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data RgbValue.
        /// </summary>
        public string RgbValue { get; set; }
    }
}
