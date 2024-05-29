using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_IntroducaoLINQ
{
    public class Adm
    {
        public static List<Person> LoadData()
        {
            var people = new List<Person>();
            people.Add(new Person() { Id = 1, Name = "Cauê", Age = 20, Telephone = "16997552763" });
            people.Add(new Person() { Id = 2, Name = "Lucas", Age = 19, Telephone = "1545612122" });
            people.Add(new Person() { Id = 3, Name = "Pietra", Age = 22, Telephone = "1651487481" });
            people.Add(new Person() { Id = 4, Name = "Adilson", Age = 45, Telephone = "487841556" });
            people.Add(new Person() { Id = 5, Name = "Fernando", Age = 10, Telephone = "487841556" });
            people.Add(new Person() { Id = 6, Name = "Amanda", Age = 25, Telephone = "168789488" });
            people.Add(new Person() { Id = 7, Name = "Ana", Age = 30, Telephone = "16997552763" });
            people.Add(new Person() { Id = 8, Name = "Gabriel", Age = 28, Telephone = "1545612122" });
            people.Add(new Person() { Id = 9, Name = "Mariana", Age = 35, Telephone = "1651487481" });
            people.Add(new Person() { Id = 10, Name = "Ricardo", Age = 40, Telephone = "487841556" });
            people.Add(new Person() { Id = 11, Name = "Carolina", Age = 18, Telephone = "487841556" });
            people.Add(new Person() { Id = 12, Name = "Pedro", Age = 33, Telephone = "168789488" });
            people.Add(new Person() { Id = 13, Name = "Isabela", Age = 29, Telephone = "16997552763" });
            people.Add(new Person() { Id = 14, Name = "Matheus", Age = 26, Telephone = "1545612122" });
            people.Add(new Person() { Id = 15, Name = "Juliana", Age = 31, Telephone = "1651487481" });
            people.Add(new Person() { Id = 16, Name = "Roberto", Age = 50, Telephone = "487841556" });
            people.Add(new Person() { Id = 17, Name = "Camila", Age = 21, Telephone = "487841556" });
            people.Add(new Person() { Id = 18, Name = "Tiago", Age = 27, Telephone = "168789488" });
            people.Add(new Person() { Id = 19, Name = "Natália", Age = 32, Telephone = "16997552763" });
            people.Add(new Person() { Id = 20, Name = "Vinícius", Age = 24, Telephone = "1545612122" });
            people.Add(new Person() { Id = 21, Name = "Vanessa", Age = 37, Telephone = "1651487481" });
            people.Add(new Person() { Id = 22, Name = "José", Age = 55, Telephone = "487841556" });
            people.Add(new Person() { Id = 23, Name = "Luiza", Age = 23, Telephone = "487841556" });
            people.Add(new Person() { Id = 24, Name = "Rafael", Age = 36, Telephone = "168789488" });
            people.Add(new Person() { Id = 25, Name = "Beatriz", Age = 34, Telephone = "16997552763" });
            people.Add(new Person() { Id = 26, Name = "Felipe", Age = 27, Telephone = "1545612122" });
            people.Add(new Person() { Id = 27, Name = "Aline", Age = 29, Telephone = "1651487481" });
            people.Add(new Person() { Id = 28, Name = "Marcelo", Age = 42, Telephone = "487841556" });
            people.Add(new Person() { Id = 29, Name = "Eduarda", Age = 19, Telephone = "487841556" });
            people.Add(new Person() { Id = 30, Name = "João", Age = 38, Telephone = "168789488" });
            return people;
        }

        public static void PrintData(List<Person> people)
        {
            foreach(var p in people) { Console.WriteLine(p); }
        }

        public static List<Person> FilterByAge(List<Person> people)
        {
            var result = new List<Person>();
            foreach (var p in people)
            {
                result.Add(p);
            }
            return result;
        }
        public static List<Person> FilterByAgeUseLinq(List<Person> people) => people.Where(p => p.Age >= 18).ToList();
        
        public static List<Person> FilterByNameUseLinq(List<Person> people) => people.Where(p => p.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
        public static List<Person> FilterPeopleByNameUseLinq(List<Person> people) => people.OrderBy(p => p.Name).ToList();
        public static List<Person> FilterPeopleByNameDescUseLinq(List<Person> people) => people.OrderByDescending(p => p.Name).ToList();
        public static List<Person> FilterPeopleContainsA(List<Person> people) => people.Where(p => p.Name.Contains("A",StringComparison.OrdinalIgnoreCase) && p.Name.Count() > 3).ToList();
    }
}
