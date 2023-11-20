using SFM.VehicleBuilder.Domain.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Application.Extensions
{
    /// <summary>
    ///   Extensions intended to be used with the <see cref="StyleOptions"/> class.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        ///   Read file from path and serillize into the object.
        /// </summary>
        /// <param name="filepath">filepath to read.</param>
        /// <typeparam name="T">The second generic type parameter.</typeparam>
        /// <returns>Returns the StyleOptions.</returns>
        public static async Task<T> ReadJsonFileAsModel<T>(this string filepath)
            where T : class
        {
            await using FileStream stream = File.OpenRead(filepath);
            var options = await JsonSerializer.DeserializeAsync<T>(stream);
            return options;
        }
    }
}