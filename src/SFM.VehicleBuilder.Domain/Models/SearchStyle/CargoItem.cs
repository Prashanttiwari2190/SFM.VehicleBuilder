using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle CargoItem.
    /// </summary>
    public class CargoItem
    {
        /// <summary>
        ///   Gets or sets a chrome data ItemNameField.
        /// </summary>
        public string ItemNameField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets a chrome data liquidCargoField.
        /// </summary>
        public bool LiquidCargoField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data cargoWeightField.
        /// </summary>
        public double CargoWeightField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle distanceFromRearAxleField.
        /// </summary>
        public double DistanceFromRearAxleField { get; set; }
    }
}
