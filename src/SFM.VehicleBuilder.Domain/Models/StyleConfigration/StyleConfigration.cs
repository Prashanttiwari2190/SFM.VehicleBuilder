using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle StyleConfigration.
    /// </summary>
    public class StyleConfigration
    {
        /// <summary>
        ///   Gets or sets a chrome data CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets a chrome data EquipmentOptions.
        /// </summary>
        public List<EquipmentOption> EquipmentOptions { get; set; }
    }
}
