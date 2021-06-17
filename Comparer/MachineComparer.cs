using CityInfo.API.Model;
using System.Collections.Generic;

namespace CityInfo.API
{
#pragma warning disable CS1591
    public class MachineComparer:IEqualityComparer<MachineAssetDto>
    {
        public bool Equals(MachineAssetDto x, MachineAssetDto y)
        {
            if (x.Machine_Name == y.Machine_Name)
                return true;
            return false;

        }
        public int GetHashCode(MachineAssetDto obj)
        {
            return (obj.Machine_Name).GetHashCode();
        }
    }
}
