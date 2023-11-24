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
    public class ConfigurationConstraint
    {
        /// <summary>
        ///   Gets or sets a chrome data nameField.
        /// </summary>
        public string ConstraintIdField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data ConstraintNameField.
        /// </summary>
        public string ConstraintNameField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data AvailableOptionsField.
        /// </summary>
        public string AvailableOptionsField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data PreselectedOptionsField.
        /// </summary>
        public string PreselectedOptionsField { get; set; }
    }
}
