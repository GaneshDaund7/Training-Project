using CityInfo.API.Model;
using System.Collections.Generic;

namespace Trainning_Project.Model
{
    public interface IGetDetailsRepository
    {
        List<MachineDto> ToGetAllDetails();
        List<string> TogetMachineByLastedSeries();
    }
}