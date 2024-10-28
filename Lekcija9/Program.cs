// See https://aka.ms/new-console-template for more information
using Lekcija9;

Console.WriteLine("Hello, World!");

using (var context = new StudentiContext())
{
    var s = context.Students.First();
    Console.WriteLine(s);
 //   Console.WriteLine($"Student: {s}, StudentID: {s.StudentId}, Name: {s.Name}, Surname: {s.Surname}");
    // Queries go here
}
