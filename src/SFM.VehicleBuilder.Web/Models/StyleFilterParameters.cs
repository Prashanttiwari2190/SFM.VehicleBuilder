using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Web
{
    /// <summary>
    ///   Style Filters to Search Style.
    /// </summary>
    public class StyleFilterParameters
    {
        /// <summary>
        ///   Gets or sets the Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        ///   Gets or sets the DivisonId.
        /// </summary>
        public int DivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public int ModelId { get; set; }
    }
}
