
namespace CityInfo.API.Model
{
    /// <summary>
    /// A MachineAsset with MachineName , AssetName, SeriesNumber.
    /// </summary>
    public class MachineAssetDto
    {
        /// <summary>
        /// Machine Name
        /// </summary>
        public string Machine_Name { get; set; }
        /// <summary>
        /// AssetName
        /// </summary>
        public string Asset_Name { get; set; }
        /// <summary>
        /// Series number.
        /// </summary>
        public string Series_No { get; set; }
       
    }
}
