using CityInfo.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trainning_Project.Model
{
    public interface IMachineAssetRepository
    {
        Task<List<MachineDto>> GetAllDetails();
        List<string> GetMachineByLastedSeries();
    }
}