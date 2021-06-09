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
      
        [HttpGet]
        public IActionResult GetAllAssets()
        {
            var result = GetDetailsDto.ToGetAllDetails().Select(x => x.Asset_Name).Distinct();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{machinename}")]
        public IActionResult GetAssetNameByMachine(string machinename)
        {


            var result = GetDetailsDto.ToGetAllDetails().Where(x => x.Machine_Name == machinename).Select(x => x.Asset_Name).ToList();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);

        }
    }
}
