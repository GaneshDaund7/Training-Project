using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Assets")]
    public class AssetController : ControllerBase
    {
        private readonly IGetDetailsRepository _getdto;

        public AssetController(IGetDetailsRepository getdto)
        {
            _getdto = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            var result = _getdto.ToGetAllDetails().Select(x => x.Asset_Name).Distinct();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{machinename}")]
        public IActionResult GetAssetNameByMachine(string machinename)
        {


            var result = _getdto.ToGetAllDetails().Where(x => x.Machine_Name == machinename).Select(x => x.Asset_Name).ToList();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);

        }
    }
}
