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
        ///   Gets or sets the StyleId.
        /// </summary>
        public int StyleId { get; set; }

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

        /// <summary>
        ///   Gets or sets the ExteriorColorId.
        /// </summary>
        public string ExteriorColorId { get; set; }

        /// <summary>
        ///   Gets or sets the CabStyleId.
        /// </summary>
        public int CabStyleId { get; set; }

        /// <summary>
        ///   Gets or sets the MinWheelBase.
        /// </summary>
        public decimal MinWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MaxWheelBase.
        /// </summary>
        public decimal MaxWheelBase { get; set; }

        /// <summary>
        ///   Gets or sets the MinPriceLevel.
        /// </summary>
        public decimal MinPriceLevel { get; set; }

        /// <summary>
        ///   Gets or sets the MaxPriceLevel.
        /// </summary>
        public decimal MaxPriceLevel { get; set; }
    }
}
