using System.Collections.Generic;
using System.Threading.Tasks;
using ChromeData;
using SFM.VehicleBuilder.Domain.Models.ChromeData;

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

        /// <summary>
        ///   Gets vehicle divison models.
        /// </summary>
        /// <param name="modelYear">.</param>
        /// <param name="divisionId">A division Id.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<Model>> GetModels(int modelYear, int divisionId);

        /// <summary>
        ///   Gets vehicle divison models.
        /// </summary>
        /// <param name="styleFilter">.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<Style>> GetStyles(StyleFilter styleFilter);

        /// <summary>
        ///   GetModelConfigurationByStyleIds.
        /// </summary>
        /// <param name="styleids">.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<ModelConfigurationElement> GetModelConfigurationByStyleIds(int[] styleids);

        /// <summary>
        ///   styleid.
        /// </summary>
        /// <param name="styleid">.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<ConfigurationElement> GetConfigurationByStyleId(int styleid);

        /// <summary>
        ///   Gets vehicle divison models.
        /// </summary>
        /// <param name="modelId">.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<Style>> GetStyles(int modelId);
    }
}
