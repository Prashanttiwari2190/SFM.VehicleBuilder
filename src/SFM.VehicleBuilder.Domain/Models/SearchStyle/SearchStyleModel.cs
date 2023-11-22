using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Domain.Models.SearchStyle
{
    /// <summary>
    ///   Models to Search Style.
    /// </summary>
    public class SearchStyleModel
    {
        /// <summary>
        ///   Gets or sets the ModelYear.
        /// </summary>
        public int ModelYear { get; set; }

        /// <summary>
        ///   Gets or sets the DivisionId.
        /// </summary>
        public int DivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the DivisionName.
        /// </summary>
        public string DivisionName { get; set; }

        /// <summary>
        ///   Gets or sets the SubdivisionId.
        /// </summary>
        public int SubdivisionId { get; set; }

        /// <summary>
        ///   Gets or sets the YSubdivisionNameear.
        /// </summary>
        public string SubdivisionName { get; set; }

        /// <summary>
        ///   Gets or sets the ModelId.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        ///   Gets or sets the ModelName.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        ///   Gets or sets the DataReleaseDate.
        /// </summary>
        public DateTime DataReleaseDate { get; set; }

        /// <summary>
        ///   Gets or sets the InitialPriceDate.
        /// </summary>
        public DateTime InitialPriceDate { get; set; }

        /// <summary>
        ///   Gets or sets the DataEffectiveDate.
        /// </summary>
        public DateTime DataEffectiveDate { get; set; }

        /// <summary>
        ///   Gets or sets the DataComment.
        /// </summary>
        public string DataComment { get; set; }
    }
}
