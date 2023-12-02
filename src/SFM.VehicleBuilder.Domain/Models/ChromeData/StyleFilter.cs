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
        ///   Gets or sets the StyleId.
        /// </summary>
        public string StyleId { get; set; }

        /// <summary>
        ///   Gets or sets the DivisonId.
        /// </summary>
        public string DivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public string ModelId { get; set; }

        /// <summary>
        ///   Gets or sets the ExteriorColorId.
        /// </summary>
        public string ExteriorColorId { get; set; }

        /// <summary>
        ///   Gets or sets the CabStyleId.
        /// </summary>
        public string CabStyleId { get; set; }

        /// <summary>
        ///   Gets or sets the MinWheelBase.
        /// </summary>
        public string MinWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MaxWheelBase.
        /// </summary>
        public string MaxWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MinPriceLevel.
        /// </summary>
        public string MinPriceLevel { get; set; }

        /// <summary>
        ///   Gets or sets the MaxPriceLevel.
        /// </summary>
        public string MaxPriceLevel { get; set; }
    }
}
