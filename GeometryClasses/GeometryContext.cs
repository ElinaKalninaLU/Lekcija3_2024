using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryClasses.GeometryClasses;

namespace GeometryClasses
{
    public class GeometryContext :DbContext
    {
        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Point>   Points { get; set; }

        public DbSet<Polygon> Polygons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyGeometry"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }

    }
}
