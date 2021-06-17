using CityInfo.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trainig_Project.Entities;
using Trainning_Project.Model;

namespace Trainig_Project.Contexts
{
#pragma warning disable 
    public class MachineAssetsContexts: DbContext
    {
        DbSet<MachineAssets> machineAssets { get; set; }
        public MachineAssetsContexts(DbContextOptions<MachineAssetsContexts> options):
            base(options)
        {

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            
        {
            var listOfEntities=GetMachineAssetData();
            foreach(var entity in listOfEntities)
            {
                modelBuilder.Entity<MachineAssets>().HasNoKey().HasData(

                       new MachineAssets()
                       {
                           Machine_Name=entity.Machine_Name,
                           Asset_Name = entity.Asset_Name,
                           Series_No=entity.Series_No

                       }


                    ) ;

            }
            
            base.OnModelCreating(modelBuilder);
        }

        private List<MachineAssetDto> GetMachineAssetData()
        {
            string path = @"C:\Users\DjS\source\repos\Trainig-Project\Trainig-Project\Matrix.csv";

            return File.ReadAllLines(path).
                Where(r => r.Length > 0).
                Select(CsvParser.ParseRow).
                ToList();

        }
    }
}
