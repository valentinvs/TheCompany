﻿using System.Data.Entity;
using TheCompany.Data;

namespace TheCompany.Web.Frontend.Models
{
    public class TheCompanyDbContext : DbContext
    {
        public TheCompanyDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Menu> Menus { get; set; }
    }
}