using CityInfo.API.Model;

namespace Trainning_Project.Model
{
    public class CsvParser
    {
        public static MachineDto ParseRow(string row)
        {
            var column = row.Split(',');

            return new MachineDto()
            {
                Machine_Name = column[0],
                Asset_Name = column[1],
                Series_No = column[2],
            };
        }
    }
}
