using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace CityInfo.API.Controller
{
    [ApiController]
    [Route("api/GetAllDetails")]
    public class GetMachinesAssetsController:ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public GetMachinesAssetsController(IMachineAssetRepository getDetailsRepository)
        {
            machineAssetRepository = getDetailsRepository ?? throw new ArgumentNullException(nameof(getDetailsRepository));
        }


        [HttpGet]
        public async Task<IActionResult> GetMachineName()
        {
            var allMachinesAssets = await machineAssetRepository.GetAllDetails();
            if (allMachinesAssets.Count == 0)
                return NotFound();
            return Ok(allMachinesAssets);
        }

    }
}
