// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Person person = new Person();

        person.FirstName = "Berkay";
        person.LastName = "Oğuz";
        person.DateOfBirthYear = 1996;
        person.NationalIdentity = 123456;

        PttManager pttManager = new PttManager(new CitizenManager());
        pttManager.GiveMask(person);
    }
}