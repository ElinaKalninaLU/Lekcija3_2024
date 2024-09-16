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
Rectangle r1 = m as Rectangle;
Console.WriteLine("r1" + r1.ToString());

Square sq_r = m as Square;
Console.WriteLine(sq_r?.ToString() ?? "nav kvadrāts");
bool t = m is Square;
bool t1 = m is Rectangle;
Console.WriteLine(t.ToString() + " " + t1.ToString());


Console.WriteLine(r.Area.ToString());
Console.WriteLine(r.Perimeter().ToString());
Console.WriteLine("Enter edge of the square");
var sq1 = new Square();
sq1.Edge = int.Parse(Console.ReadLine());
Console.WriteLine(sq1.ToString());
var sq2 = new Square(3);
Console.WriteLine(sq2.ToString());


