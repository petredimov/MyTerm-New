using Microsoft.AspNet.Identity;
using DataContextNamespace.Helpers;
using DataContextNamespace.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace DataContextNamespace.Migrations
{
    public class Configuration : DbMigrationsConfiguration<global::DataContextNamespace.DataContext>
    {
        public Configuration()
        {            
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(global::DataContextNamespace.DataContext context)
        {
            SimpleGeoName des = new SimpleGeoName();
            string xmlStr = File.ReadAllText(@"D:\ProsolutionLtd\MyTerm\MyTerm\geodata.xml");
            des = des.Deserialize(xmlStr);

            
            foreach (SimpleGeoName continent in des.Childrens)
            {
                foreach (SimpleGeoName country in continent.Childrens)
                {
                    Console.WriteLine("Country: " + country.Name + ", num of cities: " + country.Childrens.Count);

                    Country state = new Country() { Name = country.Name, Description = country.FCode };
                    state = context.Countries.Add(state);

                    foreach (SimpleGeoName city in country.Childrens)
                    {
                        City town = new City() { Name = city.Name, PostCode = city.FCode, Country = state};
                        town = context.Cities.Add(town);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
