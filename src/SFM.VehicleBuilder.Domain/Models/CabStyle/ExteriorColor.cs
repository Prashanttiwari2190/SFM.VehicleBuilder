using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   Class for ExteriorColor.
    /// </summary>
    public class ExteriorColor
    {
        /// <summary>
        ///   Gets or sets the ColorId.
        /// </summary>
        public string ColorId { get; set; }

        /// <summary>
        ///   Gets or sets the ColorName.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        ///   Gets or sets the ColorCode.
        /// </summary>
        public string ColorCode { get; set; }
    }
}
