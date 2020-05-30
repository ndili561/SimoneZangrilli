using Microsoft.EntityFrameworkCore;
using SimoneZangrilli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ContactInfo> ContactInfos { get; set; }

    }
}
