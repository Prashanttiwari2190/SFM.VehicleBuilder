using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data UserDefinedTechSpecs.
    /// </summary>
    public class UserDefinedTechSpecs
    {
        /// <summary>
        ///   Gets or sets a chrome data vehicle RoadSurfaceField.
        /// </summary>
        public RoadSurface RoadSurfaceField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data vehicle RoadGradeField.
        /// </summary>
        public double RoadGradeField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data OccupantWeightField.
        /// </summary>
        public double OccupantWeightField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data bodyLengthField.
        /// </summary>
        public double BodyLengthField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data bodyFrontalAreaField.
        /// </summary>
        public double BodyFrontalAreaField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data bodyWeightField.
        /// </summary>
        public double BodyWeightField { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data CabToBodyDistanceField.
        /// </summary>
        public double CabToBodyDistanceField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data TrailerWeightField.
        /// </summary>
        public double TrailerWeightField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data cargoItemsField.
        /// </summary>
        public CargoItem[] CargoItemsField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data bodyTypeField.
        /// </summary>
        public UserDefinedBodyType BodyTypeField { get; set; }

        /// <summary>
        ///   Gets or sets a chrome data MeasurementSystemField.
        /// </summary>
        public MeasurementSystem MeasurementSystemField { get; set; }
    }
}
