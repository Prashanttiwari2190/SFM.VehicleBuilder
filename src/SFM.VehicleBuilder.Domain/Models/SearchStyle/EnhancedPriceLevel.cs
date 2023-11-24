using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle divison.
    /// </summary>
    public class EnhancedPriceLevel
    {
        /// <summary>
        ///   Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the ShortDescription.
        /// </summary>
        public string ShortDescription { get; set; }
    }
}
