using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models.ChromeData
{
    /// <summary>
    ///   Style Filters to Search Style.
    /// </summary>
    public class StyleFilter
    {
        /// <summary>
        ///   Gets or sets the Year.
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        ///   Gets or sets the DivisonId.
        /// </summary>
        public string DivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public string ModelId { get; set; }
    }
}
