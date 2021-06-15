using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
#pragma warning disable CS1591
    [ApiController]
    [Route("api/Machines/Lastest")]
    public class GetMachineNameByLastestController:ControllerBase
    {
        /// <summary>
        /// Get Machine Names by Lastest Asset series.
        /// </summary>
        private readonly IMachineAssetRepository _machineAssetRepository;

        public GetMachineNameByLastestController(IMachineAssetRepository machineAssetRepository)
        {
            _machineAssetRepository = machineAssetRepository ?? throw new ArgumentNullException(nameof(machineAssetRepository));
        }
        /// <summary>
        /// Get Lastest Series Machines Here
        /// </summary>
        /// <returns>All Machines which are using Lastest Asset Series</returns>
        [HttpGet]
        public async Task<IActionResult> GetMachineByLastedSeries()
        {

            var lastedseriesMachines = await _machineAssetRepository.GetMachineByLastedSeries();

            if (lastedseriesMachines.Count == 0)
                return NotFound();
            return Ok(lastedseriesMachines);
        }
    }
}
