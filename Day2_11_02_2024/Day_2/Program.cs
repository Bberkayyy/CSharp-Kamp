// See https://aka.ms/new-console-template for more information
using Day_2.Entities;

Console.WriteLine("Hello, World!");

IndividualCustomer customer1 = new IndividualCustomer();
customer1.Id = 1;
customer1.NationalIdentity = "12345678922";
customer1.FirstName = "Test";
customer1.LastName = "Deneme";
customer1.CustomerNumber = "123456";

IndividualCustomer customer2 = new IndividualCustomer();
customer2.Id = 2;
customer2.NationalIdentity = "45678941231";
customer2.FirstName = "Deneme";
customer2.LastName = "Test";
customer2.CustomerNumber = "456789";

CorporateCustomer customer3 = new CorporateCustomer();
customer3.Id = 3;
customer3.Name = "Kodlamaio";
customer3.CustomerNumber = "456123";
customer3.TaxNumber = "12345678987";

CorporateCustomer customer4 = new CorporateCustomer();
customer4.Id = 4;
customer4.Name = "Abc";
customer4.CustomerNumber = "654789";
customer4.TaxNumber = "12345678945";



BaseCustomer[] customers = { customer1, customer2, customer3, customer4 };

foreach (var customer in customers)
{
    Console.WriteLine(customer.CustomerNumber);
}