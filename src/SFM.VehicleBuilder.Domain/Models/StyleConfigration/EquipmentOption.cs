using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle EquipmentOption.
    /// </summary>
    public class EquipmentOption
    {
        /// <summary>
        ///   Gets or sets a chrome data Code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets a chrome data Description.
        /// </summary>
        public List<string> Description { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data MSRP.
        /// </summary>
        public double MSRP { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle Invoice.
        /// </summary>
        public double Invoice { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle Dealer.
        /// </summary>
        public double Dealer { get; set; }
    }
}
