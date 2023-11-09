using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle model.
    /// </summary>
    public class Model
    {
        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelName.
        /// </summary>
        public string ModelName { get; set; }
    }
}
