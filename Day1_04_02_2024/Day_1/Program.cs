// See https://aka.ms/new-console-template for more information
using Day_1.Business;
using Day_1.Entities;

Console.WriteLine("Hello, World!");
CourseManager courseManager = new();
var values = courseManager.GetAll();
foreach (var item in values)
{
    Console.WriteLine(item.Name);
}
