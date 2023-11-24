using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models.SearchStyle
{
    /// <summary>
    ///   Class is for the Style Search response.
    /// </summary>
    public class Styles
    {
        /// <summary>
        ///   Gets or sets the Model class.
        /// </summary>
        public SearchStyleModel Model { get; set; }

        /// <summary>
        ///   Gets or sets the styleIdField.
        /// </summary>
        public int StyleId { get; set; }

        /// <summary>
        ///   Gets or sets the StyleName.
        /// </summary>
        public string StyleName { get; set; }

        /// <summary>
        ///   Gets or sets the StyleNameWithoutTrim.
        /// </summary>
        public string StyleNameWithoutTrim { get; set; }

        /// <summary>
        ///   Gets or sets the TrimName.
        /// </summary>
        public string TrimName { get; set; }

        /// <summary>
        ///   Gets or sets the ManufacturerModelCode.
        /// </summary>
        public string ManufacturerModelCode { get; set; }

        /// <summary>
        ///   Gets or sets the StyleGroupStyleIds.
        /// </summary>
        public int[] StyleGroupStyleIds { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the StyleGroupBase.
        /// </summary>
        public bool StyleGroupBase { get; set; }

        /// <summary>
        ///   Gets or sets the BaseMsrp.
        /// </summary>
        public double BaseMsrp { get; set; }

        /// <summary>
        ///   Gets or sets the BaseInvoice.
        /// </summary>
        public double BaseInvoice { get; set; }

        /// <summary>
        ///   Gets or sets the StartingAtInvoice.
        /// </summary>
        public double StartingAtInvoice { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the StartingAtInvoiceSpecified.
        /// </summary>
        public bool StartingAtInvoiceSpecified { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the StartingAtMsrpSpecified.
        /// </summary>
        public bool StartingAtMsrpSpecified { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the StartingAtMsrpField.
        /// </summary>
        public double StartingAtMsrpField { get; set; }

        /// <summary>
        ///   Gets or sets the Destination.
        /// </summary>
        public double Destination { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the TrueBasePrice.
        /// </summary>
        public bool TrueBasePrice { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the PassengerDoors.
        /// </summary>
        public int PassengerDoors { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the MarketClassId.
        /// </summary>
        public int MarketClassId { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the MarketClassName.
        /// </summary>
        public string MarketClassName { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the AllocationGroup.
        /// </summary>
        public string[] AllocationGroup { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the StockPhotoUrl.
        /// </summary>
        public string StockPhotoUrl { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the ConsumerFriendlyModelName.
        /// </summary>
        public string ConsumerFriendlyModelName { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the ConsumerFriendlyStyleName.
        /// </summary>
        public string ConsumerFriendlyStyleName { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the ConsumerFriendlyDrivetrain.
        /// </summary>
        public string ConsumerFriendlyDrivetrain { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the ConsumerFriendlyBodyType.
        /// </summary>
        public string ConsumerFriendlyBodyType { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the MarketingCopy.
        /// </summary>
        public string MarketingCopy { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the EnhancedBasePrices.
        /// </summary>
        public EnhancedPrice[] EnhancedBasePrices { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the PriceStateField.
        /// </summary>
        public PriceState PriceStateField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the PriceStateField.
        /// </summary>
        public SearchStyleBodyType[] BodyTypes { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the configurationStateField.
        /// </summary>
        public ConfigurationState ConfigurationStateField { get; set; }
    }
}
