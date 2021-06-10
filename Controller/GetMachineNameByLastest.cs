using Microsoft.AspNetCore.Mvc;
using System;
using Trainning_Project.Model;

namespace Trainning_Project.Controller
{
    [ApiController]
    [Route("api/Machines/Lastest")]
    public class GetMachineNameByLastest:ControllerBase
    {
        private readonly IGetDetailsRepository _getdto;

        public GetMachineNameByLastest(IGetDetailsRepository getdto)
        {
            _getdto = getdto ?? throw new ArgumentNullException(nameof(getdto));
        }
        [HttpGet]
        public IActionResult GetMachineByLastedSeries()
        {

            var Result = _getdto.TogetMachineByLastedSeries();

            if (Result == null)
                return NotFound();
            return Ok(Result);
        }
    }
}
