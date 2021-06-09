using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Machines/Lastest")]
    public class GetMachineNameByLastest:ControllerBase
    {
        [HttpGet]
        public IActionResult GetMachineByLastedSeries()
        {

            var Result = GetDetailsDto.TogetMachineByLastedSeries();

            if (Result == null)
                return NotFound();
            return Ok(Result);
        }
    }
}
