using CityInfo.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trainning_Project.Model
{
#pragma warning disable CS1591
    public interface IMachineAssetRepository
    {
        Task<List<MachineAssetDto>> GetMachineAssetDetails();
        Task<List<string>> GetMachineByLastedSeries();
    }
}