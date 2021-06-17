using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
/// <summary>
/// The Information about Machines which are using Lastest Assets Series.
/// </summary>
    [ApiController]
    [Route("api/Machines/Lastest")]
    [ApiExplorerSettings(GroupName = "TrainingProjectApiMachines")]
    public class MachineNameByLastestAssetsController:ControllerBase
    {
        /// <summary>
        /// Get Machine Names by Lastest Asset series.
        /// </summary>
        private readonly IMachineAssetRepository _machineAssetRepository;

        public MachineNameByLastestAssetsController(IMachineAssetRepository machineAssetRepository)
        {
            _machineAssetRepository = machineAssetRepository ?? throw new ArgumentNullException(nameof(machineAssetRepository));
        }
        /// <summary>
        /// Get Lastest Series Machines Here
        /// </summary>
        /// <returns>All Machines which are using Lastest Asset Series</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> MachinesByLastedAssets()
        {

            var lastedMachinesByAssets = await _machineAssetRepository.GetMachineByLastedSeries();

            if (lastedMachinesByAssets.Count == 0)
                return NotFound();
            return Ok(lastedMachinesByAssets);
        }
    }
}
