using Microsoft.AspNetCore.Mvc;
using System;
using Trainig_Project.Contexts;

namespace Trainig_Project.Controller
{
    [ApiController]
    [Route("api/Database")]
    [ApiExplorerSettings(GroupName = "TrainingProjectApiMachineAssets")]
    public class MachineAssetsDBController:ControllerBase
    {
        private readonly MachineAssetsContexts _machineAssetsContexts;

        public MachineAssetsDBController(MachineAssetsContexts machineAssetsContexts)
        {
            _machineAssetsContexts = machineAssetsContexts ?? throw new Exception(nameof(machineAssetsContexts));
        }
        [HttpGet]
        public ActionResult Database()
        {
            return Ok();
        }      
    }
}
