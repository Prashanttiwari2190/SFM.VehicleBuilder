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
    public class ModelConfigration
    {
        /// <summary>
        ///   Gets or sets a chrome data GenericColors.
        /// </summary>
        public List<GenericColors> GenericColors { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets a chrome data Wheelbase.
        /// </summary>
        public List<WheelBase> Wheelbase { get; set; }
    }
}
