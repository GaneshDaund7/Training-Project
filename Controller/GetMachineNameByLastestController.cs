using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Machines/Lastest")]
    public class GetMachineNameByLastestController:ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public GetMachineNameByLastestController(IMachineAssetRepository getdto)
        {
            machineAssetRepository = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }
        [HttpGet]
        public IActionResult GetMachineByLastedSeries()
        {

            var lastedseriesMachines =  machineAssetRepository.GetMachineByLastedSeries();

            if (lastedseriesMachines.Count == 0)
                return NotFound();
            return Ok(lastedseriesMachines);
        }
    }
}
