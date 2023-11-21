using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models.ChromeData
{
    /// <summary>
    ///   Style.
    /// </summary>
    public class Styles
    {
        private int styleIdField;

        private string styleNameField;

        private string styleNameWithoutTrimField;

        private string trimNameField;

        private string manufacturerModelCodeField;

        private int[] styleGroupStyleIdsField;

        private bool styleGroupBaseField;

        private double baseMsrpField;

        private double baseInvoiceField;

        private double startingAtInvoiceField;

        private bool startingAtInvoiceFieldSpecified;

        private double startingAtMsrpField;

        private bool startingAtMsrpFieldSpecified;

        private double destinationField;

        private bool trueBasePriceField;

        private int passengerDoorsField;

        private int marketClassIdField;

        private string marketClassNameField;

        private string[] allocationGroupField;

        private string stockPhotoUrlField;

        private string consumerFriendlyModelNameField;

        private string consumerFriendlyStyleNameField;

        private string consumerFriendlyDrivetrainField;

        private string consumerFriendlyBodyTypeField;

        private string marketingCopyField;

        public int StyleId
        {
            get
            {
                return this.styleIdField;
            }

            set
            {
                this.styleIdField = value;
            }
        }

        public string StyleName
        {
            get
            {
                return this.styleNameField;
            }

            set
            {
                this.styleNameField = value;
            }
        }

        public string StyleNameWithoutTrim
        {
            get
            {
                return this.styleNameWithoutTrimField;
            }

            set
            {
                this.styleNameWithoutTrimField = value;
            }
        }

        public string TrimName
        {
            get
            {
                return this.trimNameField;
            }

            set
            {
                this.trimNameField = value;
            }
        }

        public string ManufacturerModelCode
        {
            get
            {
                return this.manufacturerModelCodeField;
            }

            set
            {
                this.manufacturerModelCodeField = value;
            }
        }

        public int[] StyleGroupStyleIds
        {
            get
            {
                return this.styleGroupStyleIdsField;
            }

            set
            {
                this.styleGroupStyleIdsField = value;
            }
        }

        public bool StyleGroupBase
        {
            get
            {
                return this.styleGroupBaseField;
            }

            set
            {
                this.styleGroupBaseField = value;
            }
        }

        public double BaseMsrp
        {
            get
            {
                return this.baseMsrpField;
            }

            set
            {
                this.baseMsrpField = value;
            }
        }

        public double BaseInvoice
        {
            get
            {
                return this.baseInvoiceField;
            }

            set
            {
                this.baseInvoiceField = value;
            }
        }

        public double StartingAtInvoice
        {
            get
            {
                return this.startingAtInvoiceField;
            }

            set
            {
                this.startingAtInvoiceField = value;
            }
        }

        public bool StartingAtInvoiceSpecified
        {
            get
            {
                return this.startingAtInvoiceFieldSpecified;
            }

            set
            {
                this.startingAtInvoiceFieldSpecified = value;
            }
        }

        public double StartingAtMsrp
        {
            get
            {
                return this.startingAtMsrpField;
            }

            set
            {
                this.startingAtMsrpField = value;
            }
        }

        public bool StartingAtMsrpSpecified
        {
            get
            {
                return this.startingAtMsrpFieldSpecified;
            }

            set
            {
                this.startingAtMsrpFieldSpecified = value;
            }
        }

        public double Destination
        {
            get
            {
                return this.destinationField;
            }

            set
            {
                this.destinationField = value;
            }
        }

        public bool TrueBasePrice
        {
            get
            {
                return this.trueBasePriceField;
            }

            set
            {
                this.trueBasePriceField = value;
            }
        }

        public int PassengerDoors
        {
            get
            {
                return this.passengerDoorsField;
            }

            set
            {
                this.passengerDoorsField = value;
            }
        }

        public int MarketClassId
        {
            get
            {
                return this.marketClassIdField;
            }

            set
            {
                this.marketClassIdField = value;
            }
        }

        public string MarketClassName
        {
            get
            {
                return this.marketClassNameField;
            }

            set
            {
                this.marketClassNameField = value;
            }
        }

        public string[] AllocationGroup
        {
            get
            {
                return this.allocationGroupField;
            }

            set
            {
                this.allocationGroupField = value;
            }
        }

        public string StockPhotoUrl
        {
            get
            {
                return this.stockPhotoUrlField;
            }

            set
            {
                this.stockPhotoUrlField = value;
            }
        }

        public string ConsumerFriendlyModelName
        {
            get
            {
                return this.consumerFriendlyModelNameField;
            }

            set
            {
                this.consumerFriendlyModelNameField = value;
            }
        }

        public string ConsumerFriendlyStyleName
        {
            get
            {
                return this.consumerFriendlyStyleNameField;
            }

            set
            {
                this.consumerFriendlyStyleNameField = value;
            }
        }

        public string ConsumerFriendlyDrivetrain
        {
            get
            {
                return this.consumerFriendlyDrivetrainField;
            }

            set
            {
                this.consumerFriendlyDrivetrainField = value;
            }
        }

        public string ConsumerFriendlyBodyType
        {
            get
            {
                return this.consumerFriendlyBodyTypeField;
            }

            set
            {
                this.consumerFriendlyBodyTypeField = value;
            }
        }

        public string MarketingCopy
        {
            get
            {
                return this.marketingCopyField;
            }

            set
            {
                this.marketingCopyField = value;
            }
        }
    }
}
