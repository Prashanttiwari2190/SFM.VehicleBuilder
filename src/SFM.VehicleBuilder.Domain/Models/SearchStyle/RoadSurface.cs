using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A Enum class for RoadSurface.
    /// </summary>
    public enum RoadSurface
    {
        /// <summary>
        ///   Enum for the Concrete.
        /// </summary>
        Concrete,

        /// <summary>
        ///   Enum for the Asphalt.
        /// </summary>
        Asphalt,

        /// <summary>
        ///   Enum for the HardGravel.
        /// </summary>
        HardGravel,

        /// <summary>
        ///   Enum for the LooseGravel.
        /// </summary>
        LooseGravel,

        /// <summary>
        ///   Enum for the Sand.
        /// </summary>
        Sand,
    }
}
