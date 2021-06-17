using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trainig_Project.Entities
{
    public class MachineAssets
    {

        public string Machine_Name { get; set; }
        public string Asset_Name { get; set; }
        public string Series_No { get; set; }
    }
}
