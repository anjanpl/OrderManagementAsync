using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(
                    new Supplier
                    {
                        Id = 1,
                        Name = "Anjan",
                        AddresslineOne = "Houston",
                        AddresslineTwo = "AB",
                        City = "Texas",
                        PostalCode = "5458878",
                        State = StateList.Illinois
                    },
                    new Supplier
                    {
                        Id = 2,
                        Name = "Ashis",
                        AddresslineOne = "California",
                        AddresslineTwo = "ABC",
                        City = "California",
                        PostalCode = "8898989",
                        State = StateList.Alabama
                    }
                );
        }
    }
}
