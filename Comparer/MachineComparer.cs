using CityInfo.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class MachineComparer:IEqualityComparer<MachineDto>
    {

        public bool Equals(MachineDto x, MachineDto y)
        {
            if (x.Machine_Name == y.Machine_Name)
                return true;
            return false;

        }

        public int GetHashCode(MachineDto obj)
        {
            return (obj.Machine_Name).GetHashCode();
        }
    }
}
