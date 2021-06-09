using CityInfo.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{

    // Dummy Data..
    public class DataStore
    {
        public List<MachineDto> csvreaderdto { get; set; }
        

        public DataStore()
        {
            csvreaderdto = new List<MachineDto>()
            {
                new MachineDto()
                {
                    Machine_Name = "C300",
                    Asset_Name = "Cutter head",
                    Series_No= "S6"
                },
                new MachineDto()
                {
                    Machine_Name = "C40",
                    Asset_Name = "Cutter head",
                    Series_No = "S7"
                },
                new MachineDto()
                {
                    Machine_Name = "C300",
                    Asset_Name = "Blade safety cover",
                    Series_No = "S10"
                },
                 new MachineDto()
                {

                    Machine_Name = "C60",
                    Asset_Name = "Blade safety cover",
                    Series_No = "S11"
                },
                  new MachineDto()
                {

                    Machine_Name = "C300",
                    Asset_Name = "Deburring blades",
                    Series_No = "S6"
                },
                   new MachineDto()
                {
                    Machine_Name = "C60",
                    Asset_Name = "Cutter head",
                    Series_No = "S8"
                },
                    new MachineDto()
                {

                    Machine_Name = "C60",
                    Asset_Name = "Clamping fixture",
                    Series_No = "S2"
                },
                new MachineDto()
                {

                    Machine_Name = "C40",
                    Asset_Name = "Blade safety cover",
                    Series_No = "S11"
                },
                new MachineDto()
                {

                    Machine_Name = "C40",
                    Asset_Name = "Shutter gripper",
                    Series_No = "S3"
                },
                new MachineDto()
                {

                    Machine_Name = "C50",
                    Asset_Name = "Shutter",
                    Series_No = "S3"
                }



            };


        }

    }
}
