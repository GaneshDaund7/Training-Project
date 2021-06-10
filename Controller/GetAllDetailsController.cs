using Microsoft.AspNetCore.Mvc;
using System;
using Trainning_Project.Model;

namespace CityInfo.API.Controller
{
    [ApiController]
    [Route("api/GetAllDetails")]
    public class GetAllDetailsController:ControllerBase
    {
        private readonly IGetDetailsRepository _getdto;

        public GetAllDetailsController(IGetDetailsRepository getDetailsRepository)
        {
            _getdto = getDetailsRepository ?? throw new ArgumentNullException(nameof(getDetailsRepository));
        }


        [HttpGet]
        public IActionResult GetMachineName()
        {
            var result = _getdto.ToGetAllDetails();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

    }
}
