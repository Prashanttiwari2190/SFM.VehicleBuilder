using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data BodyType.
    /// </summary>
    public class SearchStyleBodyType
    {
        /// <summary>
        ///   Gets or sets the BodyTypeId.
        /// </summary>
        public int BodyTypeId { get; set; }

        /// <summary>
        ///   Gets or sets the BodyTypeName.
        /// </summary>
        public string BodyTypeName { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether gets or sets the Primary.
        /// </summary>
        public bool Primary { get; set; }
    }
}
