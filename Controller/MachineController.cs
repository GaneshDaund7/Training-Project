using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Machines")]
    public class MachineController:ControllerBase
    {
        private readonly IMachineAssetRepository _getdto;

        public MachineController(IMachineAssetRepository getdto)
        {
            _getdto = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMachines()
        {
            var machineAsset = await _getdto.GetAllDetails();
            var machineNames= machineAsset.Select(x => x.Machine_Name).Distinct().ToList();
            if (machineNames.Count ==0)
                return NotFound();
            return Ok(machineNames);
        }

        [HttpGet("{assetname}")]
        public async Task<IActionResult> GetMachineNameByAsset(string assetname)
        {
            assetname = " " + assetname;
            var machineAssets = await _getdto.GetAllDetails();
            var asset=machineAssets.Where(x => x.Asset_Name == assetname).Select(x => x.Machine_Name).ToList();
            if (asset.Count == 0)
                return NotFound();
            return Ok(asset);
        }
    }
}
