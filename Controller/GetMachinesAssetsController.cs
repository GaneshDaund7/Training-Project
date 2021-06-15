using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace CityInfo.API.Controller
{
#pragma warning disable CS1591
    [ApiController]
    [Route("api/GetMachineAssetDetails")]
    public class GetMachinesAssetsController:ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public GetMachinesAssetsController(IMachineAssetRepository getDetailsRepository)
        {
            machineAssetRepository = getDetailsRepository ?? throw new ArgumentNullException(nameof(getDetailsRepository));
        }

        /// <summary>
        /// Get all Machine names with All Assets and Series number.
        /// </summary>
        /// <returns>All data from file</returns>
        [HttpGet]
        public async Task<IActionResult> GetMachineName()
        {
            var allMachinesAssets = await machineAssetRepository.GetMachineAssetDetails();
            if (allMachinesAssets.Count == 0)
                return NotFound();
            return Ok(allMachinesAssets);
        }

    }
}
