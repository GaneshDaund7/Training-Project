using CityInfo.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    /// <summary>
    /// The Information about Assets.
    /// </summary>
    [Produces("application/json","application/xml")]
    [ApiController]
    [Route("api/Assets")]
    [ApiExplorerSettings(GroupName = "TrainingProjectApiAssets")]
    
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllAssetsAnyc()
        {
            var allAssets = await machineAssetRepository.GetAllAssets();
            if (allAssets.Count == 0)
                return NotFound();

            return Ok(allAssets);
        }
        /// <summary>
        /// Get Assets which given machine uses
        /// </summary>
        /// <param name="machinename">machine name to get Assets which machine using</param>
        /// <returns>all Assets which given machine uses</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{machinename}")]
        public async  Task<IActionResult> GetAssetNamesByMachine(string machinename)
        {
            var assetsNamesByMachine = await machineAssetRepository.GetAssetNamesByMachine(machinename);
            if ( assetsNamesByMachine .Count == 0)
                return NotFound();
            return Ok(assetsNamesByMachine);

        }
    }
}
