using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
#pragma warning disable CS1591
    [ApiController]
    [Route("api/Machines")]
    public class MachineController:ControllerBase
    {
        private readonly IMachineAssetRepository machineAssetRepository;

        public MachineController(IMachineAssetRepository machineAssetRepository1)
        {
            machineAssetRepository = machineAssetRepository1 ?? throw new ArgumentNullException(nameof(machineAssetRepository1));
        }
        /// <summary>
        /// Get all Machine Names here
        /// </summary>
        /// <returns>All machines which are present in file</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllMachines()
        {
            var machineAsset = await machineAssetRepository.GetMachineAssetDetails();
            var machineNames= machineAsset.Select(x => x.Machine_Name).Distinct().ToList();
            if (machineNames.Count ==0)
                return NotFound();
            return Ok(machineNames);
        }
        /// <summary>
        /// Get all machines which are using given asset
        /// </summary>
        /// <param name="assetname"></param>
        /// <returns></returns>
        [HttpGet("{assetname}")]
        public async Task<IActionResult> GetMachineNameByAsset(string assetname)
        {
            assetname = " " + assetname;
            var machineAssets = await machineAssetRepository.GetMachineAssetDetails();
            var asset=machineAssets.Where(x => x.Asset_Name == assetname).Select(x => x.Machine_Name).ToList();
            if (asset.Count == 0)
                return NotFound();
            return Ok(asset);
        }
    }
}
