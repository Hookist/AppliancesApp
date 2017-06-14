using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppliancesApp.Models.DbModels
{
    public class ApplianceContext : DbContext
    {
        public ApplianceContext()
            : base("AppliancesConnection")
        {

        }

        public DbSet<ApplianceRestriction> ApplianceRestrictions { get; set; }
        public DbSet<Appliance> Appliances { get; set; }
    }
}