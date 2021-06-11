using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Assets")]
    public class AssetController : ControllerBase
    {
        private readonly IMachineAssetRepository _getdto;

        public AssetController(IMachineAssetRepository getdto)
        {
            _getdto = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var machineAsset = await _getdto.GetAllDetails();
            var allAssets=machineAsset.Select(x => x.Asset_Name).Distinct().ToList();
            
            if (allAssets.Count == 0)
                return NotFound();

            return Ok(allAssets);
        }

        [HttpGet("{machinename}")]
        public async  Task<IActionResult> GetAssetNameByMachine(string machinename)
        {
            var machineAsset = await _getdto.GetAllDetails();
            var requiredAsset= machineAsset.Where(x => x.Machine_Name == machinename).Select(x => x.Asset_Name).ToList();
            if (requiredAsset.Count == 0)
                return NotFound();
            return Ok(requiredAsset);

        }
    }
}
