using CityInfo.API;
using CityInfo.API.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Trainning_Project.Model
{
    public class GetDetailsDto
    {
        static string path = @"C:\Users\DjS\Desktop\end\CityInfo.API\Matrix.csv";

        public static List<MachineDto> ToGetAllDetails()
        {

            return File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();
        }



        public static List<string> TogetMachineByLastedSeries()
        {


            var Result1 = File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                OrderByDescending(x => x.Series_No).
                ThenBy(x => x.Asset_Name).
                GroupBy(asset => asset.Asset_Name).
                Select(g => g.First()).
                ToList();

            var Result2 = File.ReadLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();

            var Temp_Result = Result2.Except(Result1, new EqualityComparer()).ToList();


            var Final_Result = Result1.Except(Temp_Result, new MachineComparer()).Select(x=>x.Machine_Name).ToList();

            return Final_Result;

        }
    }
}
