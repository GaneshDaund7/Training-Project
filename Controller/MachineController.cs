using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
  /// <summary>
  /// The Information about Machines
  /// </summary>
    [ApiController]
    [Route("api/Machines")]
    [ApiExplorerSettings(GroupName = "TrainingProjectApiMachines")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllMachines()
        {
            var allMachineNames = await machineAssetRepository.GetAllMachines();
            if (allMachineNames.Count ==0)
                return NotFound();
            return Ok(allMachineNames);
        }
        /// <summary>
        /// Get all machines which are using given asset
        /// </summary>
        /// <param name="assetname">Asset name to get machines which given asset using</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{assetname}")]
        public async Task<IActionResult> MachineNamesByAsset(string assetname)
        {
            var machineNamesbyAssets = await machineAssetRepository.GetMachinesNameByAsset(assetname);
            if (machineNamesbyAssets.Count == 0)
                return NotFound();
            return Ok(machineNamesbyAssets);
        }
    }
}
