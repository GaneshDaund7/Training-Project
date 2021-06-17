using CityInfo.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trainning_Project.Model
{
#pragma warning disable CS1591
    public interface IMachineAssetRepository
    {
        Task<List<MachineAssetDto>> GetMachineAssetDetails();
        Task<List<string>> GetMachineByLastedSeries();
        Task<List<string>> GetAssetNamesByMachine(string machinename);
        Task<List<string>> GetAllAssets();
        Task <List<string>>GetMachinesNameByAsset(string assetname);
        Task<List<string>> GetAllMachines();
    }
}