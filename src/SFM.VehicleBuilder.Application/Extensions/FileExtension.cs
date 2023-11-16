using SFM.VehicleBuilder.Domain.Models;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SFM.VehicleBuilder.Application
{
    /// <summary>
    ///   Extensions intended to be used with the <see cref="StyleOptions"/> class.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        ///   Read file from path and serillize into the object.
        /// </summary>
        /// <returns>Returns the StyleOptions.</returns>
        public static async Task<StyleOptions> FileRead()
        {
            var styleOption = new StyleOptions();
            var filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filepath = filepath + @"\ChromeData\chromeDataStatic.json";

            // Let's load some JSON files asynchronously ...
            await using FileStream stream = File.OpenRead(filepath);
            styleOption = await JsonSerializer.DeserializeAsync<StyleOptions>(stream);
            return styleOption;
        }
    }
}