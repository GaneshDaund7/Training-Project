using CityInfo.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class EqualityComparer:IEqualityComparer<MachineDto>
    {
        public bool Equals(MachineDto x, MachineDto y)
        {
            if (x.Asset_Name == y.Asset_Name && x.Machine_Name == y.Machine_Name && x.Series_No == y.Series_No)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(MachineDto obj)
        {
            return (obj.Series_No + obj.Machine_Name + obj.Asset_Name).GetHashCode();
        }
    }
}
