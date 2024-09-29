// See https://aka.ms/new-console-template for more information
using GeometryClasses;
using System.Linq.Expressions;
using System.Net;
using System.Text.RegularExpressions;
using System.Transactions;

Console.WriteLine("Hello, World!");

//var r = new Rectangle();
//r.Height = 2;
//r.Width=3;
//r.Name = "r";
//Console.WriteLine(r.ToString());
//Console.WriteLine(r.izdruka());
//GeometryClass m = r;
//Console.WriteLine(m.ToString());
//Console.WriteLine(m.izdruka());
//Rectangle r1 = m as Rectangle;
//Console.WriteLine("r1" + r1.ToString());

//Square sq_r = m as Square;
//Console.WriteLine(sq_r?.ToString() ?? "nav kvadrāts");
//bool t = m is Square;
//bool t1 = m is Rectangle;
//Console.WriteLine(t.ToString() + " " + t1.ToString());


//Console.WriteLine(r.Area.ToString());
//Console.WriteLine(r.Perimeter().ToString());
//Console.WriteLine("Enter edge of the square");
//var sq1 = new Square();
//sq1.Edge = int.Parse(Console.ReadLine());
//Console.WriteLine(sq1.ToString());
//var sq2 = new Square(3);
//Console.WriteLine(sq2.ToString());

IDataManager dm = new GeometryDataManager();
dm.CreateTestData();
Console.WriteLine("Print: \n" + dm.Print());
Console.WriteLine("Enter edge of a square");
var sq1 = new Square();
//try
//{
    sq1.Edge = int.Parse(Console.ReadLine());
    var gdm = (GeometryDataManager)dm;
    gdm.AddFigure(sq1);
//}
//catch (ArgumentOutOfRangeException e)
//{ Console.WriteLine("The value must be positive."); }
//catch (Exception e)
//{ Console.WriteLine("Error."); }

Console.WriteLine("Print: \n" + dm.Print());
dm.Save();
dm.Reset();
Console.WriteLine("Print: \n" + dm.Print());
dm.Load();
Console.WriteLine("Print: \n" + dm.Print());

//Console.WriteLine("Enter phone number of 8 digits");
//var s = Console.ReadLine();
//Console.WriteLine(Regex.Match(s, @"^\d{8}$|^\+371\d{8}$").Success);


