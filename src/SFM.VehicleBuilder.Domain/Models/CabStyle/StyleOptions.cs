using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   StyleOptions.
    /// </summary>
    public class StyleOptions
    {
        /// <summary>
        ///   Gets or sets the CabStyles.
        /// </summary>
        public IEnumerable<CabStyle> CabStyle { get; set; }

        /// <summary>
        ///   Gets or sets the ExteriorColors.
        /// </summary>
        public IEnumerable<ExteriorColor> ExteriorColor { get; set; }
    }
}
