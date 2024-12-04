    using GeometryClasses;
    using GeometryClasses.GeometryClasses;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace FiguresDB
    {
        public class GeometryDBDataManager : IDataManager, IAddFigure
        {
            private GeometryContext context;
            private string _connectionString = "";

            public GeometryDBDataManager()
            {
                context = new GeometryContext();
            }

            public GeometryDBDataManager(string cs)
            {
                _connectionString = cs;
         //       context = new GeometryContext(_connectionString);
            }

            public List<GeometryClass> figures
            {
                get
                {
                    var listr = context.Rectangles.Cast<GeometryClass>().ToList();

                    var lists = context.Squares.Cast<GeometryClass>().ToList();
                    var listp = context.Polygons.Cast<GeometryClass>().ToList();
                    var a = listr.Union(lists).Union(listp).ToList();
                    return a;
                }
                set
                {
                    var removef = figures.Except(value);
                    foreach (var f in removef)
                    {
                        if (f is Rectangle) { context.Rectangles.Remove((Rectangle)f); }
                        else if (f is GeometryClasses.GeometryClasses.Square) { context.Squares.Remove((GeometryClasses.GeometryClasses.Square)f); }
                        else if (f is Polygon) { context.Polygons.Remove((Polygon)f); }
                    }
                    var addf = value.Except(figures);
                    foreach (var f in addf)
                    {
                        if (f is Rectangle) { context.Rectangles.Add((Rectangle)f); }
                        else if (f is GeometryClasses.GeometryClasses.Square) { context.Squares.Add((GeometryClasses.GeometryClasses.Square)f); }
                        else if (f is Polygon) { context.Polygons.Add((Polygon)f); }
                    }
                }
            }
            public bool AddFigure(GeometryClass f)
            {
                try
                {
                    if (f is Rectangle)
                    {
                        context.Rectangles.Add((Rectangle)f);
                        return true;
                    }
                    if (f is Polygon)
                    {
                        context.Polygons.Add((Polygon)f);
                        return true;
                    }
                    if (f is GeometryClasses.GeometryClasses.Square)
                    {

                        context.Squares.Add((GeometryClasses.GeometryClasses.Square)f);
                        return true;
                    }
                    return false;
                }
                catch { return false; }
            }

            public bool CreateTestData()
            {
                var sq1 = new Square(5) { };
                var sq2 = new Square() { Edge = 6 };
                var rt1 = new Rectangle() { Width = 2, Height = 3 };
                AddFigure(sq1);
                AddFigure(sq2);
                AddFigure(rt1);
                AddFigure(new Rectangle() { Width = 5, Height = 6 });
                //          figures = new List<GeometryClass>() { sq1, sq2 , rt1, new Rectangle() { Width = 5, Height = 6 } };
                var po = new Polygon() { };
                po.AddPoint(new Point() { x = 3, y = 5 });
                po.AddPoint(new Point() { x = 4, y = 1 });
                po.AddPoint(new Point() { x = 1, y = 1 });
                po.AddPoint(new Point() { x = 0, y = 0 });
                AddFigure(po);
                return true;
            }

            public bool Load()
            {
                try
                {
                    if (_connectionString != "")
                    {
               //         context = new GeometryContext(_connectionString);
                    }
                    else
                    {
                        context = new GeometryContext();
                    }
                    return true;
                }
                catch { return false; }
            }

            public string Print()
            {
                string p;
                p = "Squares: " + Environment.NewLine;
                foreach (var f in context.Squares)
                {
                    p += f.ToString() + Environment.NewLine;
                }
                p += "Rectangles: " + Environment.NewLine;
                foreach (var f in context.Rectangles)
                {
                    p += f.ToString() + Environment.NewLine;
                }
                p += "Polygons: " + Environment.NewLine;
                foreach (var f in context.Polygons)
                {
                    p += f.ToString() + Environment.NewLine;
                }
                return p;
            }

            public bool Reset()
            {
                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    return true;
                }
                catch { return false; }
            }

            public bool Save()
            {
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }
    }
