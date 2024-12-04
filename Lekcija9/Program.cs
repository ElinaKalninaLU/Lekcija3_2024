// See https://aka.ms/new-console-template for more information
using Lekcija9;
using GeometryClasses;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new StudentiContext())
{
    var s = context.Students.First();
    Console.WriteLine(s);
 //   Console.WriteLine($"Student: {s}, StudentID: {s.StudentId}, Name: {s.Name}, Surname: {s.Surname}");
    // Queries go here
}

using (var context1 = new GeometryContext())
{
    var r = new Rectangle() { Height = 6, Width = 3 };
    context1.Rectangles.Add(r);
    context1.SaveChanges();
    var r1 = context1.Rectangles.First();
    context1.Rectangles.Remove(r1);
    context1.SaveChanges();
    Console.WriteLine(context1.Rectangles.Count());
    //var p1 = new Point(1, 2);
    //var p2 = new Point(2, 3);
    //var p3 = new Point(4, 2);
    //var po = new Polygon() { Points = { p1, p2 , p3} };
    //context1.Polygons.Add(po);
    //context1.SaveChanges();

   var po= context1.Polygons.Include("Points").First();
    Console.WriteLine(po);
}
