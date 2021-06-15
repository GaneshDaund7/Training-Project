using CityInfo.API;
using CityInfo.API.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trainig_Project.Comparer;

namespace Trainning_Project.Model
{
#pragma warning disable CS1591
    public class  MachineAssetRepository:IMachineAssetRepository
    {

        string path = @"C:\Users\DjS\Desktop\end\CityInfo.API\Matrix.csv";

        public async  Task<List<MachineAssetDto>> GetMachineAssetDetails()
        {
            Task<string[]> taskToReadMachineAssetCombinations =  File.ReadAllLinesAsync(path);
            var machineAssetCombinations  = await taskToReadMachineAssetCombinations;


            return machineAssetCombinations.
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();
        }

        public async Task<List<string>> GetMachineByLastedSeries()
        {

            var taskToReadMachineAssetCombinations = await File.ReadAllLinesAsync(path);

            var machinesWithLastestAssets= taskToReadMachineAssetCombinations.
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                OrderByDescending(x => x.Series_No).
                ThenBy(x => x.Asset_Name).
                GroupBy(asset => asset.Asset_Name).
                Select(g => g.First()).
                ToList();

            var machinesWithOldesAssets = File.ReadLines(path).
                Where(row => row.Length > 0).
                Select(CsvParser.ParseRow).
                Except(machinesWithLastestAssets, new MachineAssetComparer()).
                ToList();

            var remainingLastestAsset = machinesWithOldesAssets.Intersect(machinesWithLastestAssets, new AssetSeriesComparer()).ToList();
            machinesWithLastestAssets.AddRange(remainingLastestAsset);

            var removingRemainingLastestAsssetFromOldestAsset = machinesWithOldesAssets.Except(remainingLastestAsset, new AssetSeriesComparer()).ToList();


            var lastestAsssetMachines = machinesWithLastestAssets.Except(removingRemainingLastestAsssetFromOldestAsset, new MachineComparer()).
                                         Select(x => x.Machine_Name).ToList();

            return lastestAsssetMachines;

        }
    }
}
