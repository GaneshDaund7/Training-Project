using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Trainning_Project.Model;

namespace CityInfo.API.Controller
{
    [ApiController]
    [Route("api/GetAllDetails")]
    public class GetAllDetailsController:ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetMachineName()
        {
            var result = GetDetailsDto.ToGetAllDetails();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }



      
        



        

        




           

    }
}
