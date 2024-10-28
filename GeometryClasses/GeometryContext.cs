using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    public class GeometryContext :DbContext
    {
        DbSet<Rectangle> Rectangles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyGeometry"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }

    }
}
