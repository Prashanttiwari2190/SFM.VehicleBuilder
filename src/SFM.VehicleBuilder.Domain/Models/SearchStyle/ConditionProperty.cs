using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data ConditionProperty.
    /// </summary>
    public class ConditionProperty
    {
        /// <summary>
        ///   Gets or sets a chrome data nameField.
        /// </summary>
        public string NameField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data valueField.
        /// </summary>
        public string ValueField { get; set; }
    }
}
