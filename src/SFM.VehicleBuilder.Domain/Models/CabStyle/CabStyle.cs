using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///  get and set the CabStyle data.
    /// </summary>
    public class CabStyle
    {
        /// <summary>
        ///   Gets or sets the CabStyleId.
        /// </summary>
        public int CabStyleId { get; set; }

        /// <summary>
        ///   Gets or sets the CabStyleName.
        /// </summary>
        public string CabStyleName { get; set; }
    }
}
