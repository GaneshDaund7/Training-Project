using CityInfo.API.Model;

namespace Trainning_Project.Model
{
#pragma warning disable CS1591
    public class CsvParser
    {  
        public static MachineAssetDto ParseRow(string row)
        {
            var column = row.Split(',');

            return new MachineAssetDto()
            {
                Machine_Name = column[0],
                Asset_Name = column[1],
                Series_No = column[2],
            };
        }
    }
}
