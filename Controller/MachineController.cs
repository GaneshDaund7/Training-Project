using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Machines")]
    public class MachineController:ControllerBase
    {
        private readonly IGetDetailsRepository _getdto;

        public MachineController(IGetDetailsRepository getdto)
        {
            _getdto = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }
        [HttpGet]
       public IActionResult GetAllMachines()
        {
            var result = _getdto.ToGetAllDetails().Select(x => x.Machine_Name).Distinct();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{assetname}")]
        public IActionResult GetMachineNameByAsset(string assetname)
        {
            assetname = " " + assetname;
            var result =_getdto.ToGetAllDetails().Where(x => x.Asset_Name == assetname).Select(x => x.Machine_Name).ToList();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }
    }
}
