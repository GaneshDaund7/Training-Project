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
        string path = @"C:\Users\DjS\Desktop\end\CityInfo.API\Matrix.csv";
        [HttpGet]
       public IActionResult GetAllMachines()
        {
            var result = GetDetailsDto.ToGetAllDetails().Select(x => x.Machine_Name).Distinct();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{assetname}")]
        public IActionResult GetMachineNameByAsset(string assetname)
        {
            assetname = " " + assetname;
            var result = GetDetailsDto.ToGetAllDetails().Where(x => x.Asset_Name == assetname).Select(x => x.Machine_Name).ToList();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }
    }
}
