using System.Collections.Generic;
using System.Threading.Tasks;
using ChromeData;

namespace SFM.VehicleBuilder.Data.Services.ChromeData
{
    /// <summary>
    ///   Provides service to interact with Chrome Data API Service.
    /// </summary>
    public interface IChromeDataService
    {
        /// <summary>
        ///   Gets vehicle Model Years.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<int[]> GetModelYears();

        /// <summary>
        ///   Gets vehicle divisons.
        /// </summary>
        /// <param name="modelYear">.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<Division>> GetDivisions(int modelYear);
    }
}
