// See https://aka.ms/new-console-template for more information
using _5by5_IntroducaoLINQ;
using System.Xml.Linq;

Console.WriteLine("Inicio do processamento");

var people = Adm.LoadData();
Adm.PrintData(people);
//Console.WriteLine("By Age");
//Adm.PrintData(Adm.FilterByAgeUseLinq(people));
//Console.WriteLine("===============================\nby First letter = A");
//Adm.PrintData(Adm.FilterByNameUseLinq(people));
//Console.WriteLine("===============================\nOrder by name");
//Adm.PrintData(Adm.FilterPeopleByNameUseLinq(people));
Console.WriteLine("==============================");
Adm.PrintData(Adm.FilterPeople4(people));