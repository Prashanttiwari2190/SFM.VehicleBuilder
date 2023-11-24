using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data for ConfigurationState.
    /// </summary>
    public class ConfigurationState
    {
        /// <summary>
        ///   Gets or sets a chrome data DataVersionField.
        /// </summary>
        public DateTime DataVersionField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data StyleIdField.
        /// </summary>
        public int StyleIdField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data FullyConfiguredField.
        /// </summary>
        public bool FullyConfiguredField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle OrderAvailabilityField.
        /// </summary>
        public OrderAvailability OrderAvailabilityField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data vehicle SpecialEquipmentEnabledField.
        /// </summary>
        public bool SpecialEquipmentEnabledField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data vehicle OptionOrderLogicDisabledField.
        /// </summary>
        public bool OptionOrderLogicDisabledField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data vehicle InitialPricingEnabledField.
        /// </summary>
        public bool InitialPricingEnabledField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle ChromeOptionCodeToggleStreamField.
        /// </summary>
        public string[] ChromeOptionCodeToggleStreamField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle SelectedChromeOptionCodesField.
        /// </summary>
        public string[] SelectedChromeOptionCodesField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle ConditionPropertiesField.
        /// </summary>
        public ConditionProperty[] ConditionPropertiesField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle ConstraintField.
        /// </summary>
        public ConfigurationConstraint ConstraintField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle UserDefinedTechSpecsField.
        /// </summary>
        public UserDefinedTechSpecs UserDefinedTechSpecsField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle SerializedValueField.
        /// </summary>
        public string SerializedValueField { get; set; }
    }
}
