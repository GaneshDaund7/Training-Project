using CityInfo.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
