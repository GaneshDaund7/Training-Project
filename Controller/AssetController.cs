using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
#pragma warning disable CS1591
    [Produces("application/json")]
    [ApiController]
    [Route("api/Assets")]
    public class AssetController : ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public AssetController(IMachineAssetRepository getdto)
        {
            machineAssetRepository = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }
        /// <summary>
        /// Get All Asset names here.
        /// </summary>
        /// <returns>All Assets present in the file</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAssetsAnyc()
        {
            var machineAsset = await machineAssetRepository.GetMachineAssetDetails();
            var allAssets=machineAsset.Select(x => x.Asset_Name).Distinct().ToList();
            
            if (allAssets.Count == 0)
                return NotFound();

            return Ok(allAssets);
        }
        /// <summary>
        /// Get Assets which given machine uses
        /// </summary>
        /// <param name="machinename"></param>
        /// <returns>all Assets which given machine uses</returns>
        [HttpGet("{machinename}")]
        public async  Task<IActionResult> GetAssetNamesByMachine(string machinename)
        {
            var machineAsset = await machineAssetRepository.GetMachineAssetDetails();
            var requiredAsset= machineAsset.Where(x => x.Machine_Name == machinename).Select(x => x.Asset_Name).ToList();
            if (requiredAsset.Count == 0)
                return NotFound();
            return Ok(requiredAsset);

        }
    }
}
