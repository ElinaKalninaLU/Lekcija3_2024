// See https://aka.ms/new-console-template for more information
using GeometryClasses;
using GeometryClasses.GeometryClasses;

Console.WriteLine("Hello, World!");

var r = new Rectangle();
r.Height = 2;
r.Width=3;
r.Name = "r";
Console.WriteLine(r.ToString());
Console.WriteLine(r.izdruka());
GeometryClass m = r;
Console.WriteLine(m.ToString());
Console.WriteLine(m.izdruka());


Console.WriteLine(r.Area.ToString());
Console.WriteLine(r.Perimeter().ToString());
Console.WriteLine("Enter edge of the square");
var sq1 = new Square();
sq1.Edge = int.Parse(Console.ReadLine());
Console.WriteLine(sq1.ToString());
var sq2 = new Square(3);
Console.WriteLine(sq2.ToString());


