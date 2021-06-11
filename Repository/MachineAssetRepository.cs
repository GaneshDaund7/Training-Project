using CityInfo.API;
using CityInfo.API.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Trainning_Project.Model
{
    public class  MachineAssetRepository:IMachineAssetRepository
    {
        string path = @"C:\Users\DjS\Desktop\end\CityInfo.API\Matrix.csv";

        public async  Task<List<MachineDto>> GetAllDetails()
        {
            Task<string[]> taskToReadMachineAssetCombinations =  File.ReadAllLinesAsync(path);
            var machineAssetCombinations  = await taskToReadMachineAssetCombinations;


            return machineAssetCombinations.
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();
        }

        public List<string>GetMachineByLastedSeries()
        {
           
            var machinesWithLastestAssets = File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                OrderByDescending(x => x.Series_No).
                ThenBy(x => x.Asset_Name).
                GroupBy(asset => asset.Asset_Name).
                Select(g => g.First()).
                ToList();

            var allMachinesAssets= File.ReadLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();

            var machinesWithOldesAssets = allMachinesAssets.Except(machinesWithLastestAssets, new MachineAssetComparer()).ToList();
            var lastestAsssetMachines = machinesWithLastestAssets.Except(machinesWithOldesAssets, new MachineComparer()).
                                         Select(x => x.Machine_Name).ToList();

            return lastestAsssetMachines;

        }
    }
}
