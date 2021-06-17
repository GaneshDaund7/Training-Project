using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace CityInfo.API.Controller
{
/// <summary>
/// The Information about Machines and Assets.
/// </summary>
    [ApiController]
    [Route("api/GetMachineAssetDetails")]
    [ApiExplorerSettings(GroupName = "TrainingProjectApiMachineAssets")]
    public class MachinesAssetsController:ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public MachinesAssetsController(IMachineAssetRepository getDetailsRepository)
        {
            machineAssetRepository = getDetailsRepository ?? throw new ArgumentNullException(nameof(getDetailsRepository));
        }

        /// <summary>
        /// Get all Machine names with All Assets and Series number.
        /// </summary>
        /// <returns>All data from file</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachineName()
        {
            var allMachinesAssets = await machineAssetRepository.GetMachineAssetDetails();
            if (allMachinesAssets.Count == 0)
                return NotFound();
            return Ok(allMachinesAssets);
        }

    }
}
