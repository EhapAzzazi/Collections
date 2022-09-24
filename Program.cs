
namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Using Lists
            //var countriesArr = new Country[] { new Country { Name = "Egypt", ISOCode = "EGY" }, new Country { Name = "Brazil", ISOCode = "BRA" }, new Country { Name = "Iraq", ISOCode = "IRQ" } };

            //List<Country> countriesList = new List<Country>(4); // when the list expands, her Capacity == (the last Capacity * 2)
            //Country.Print(countriesList); // Count == 0, Capacity == 4;

            //countriesList.AddRange(countriesArr);// Add an array
            //Country.Print(countriesList);// Count == 3, Capacity == 4;

            //countriesList.Add(new Country { Name = "France", ISOCode = "FRA" }); //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //Country.Print(countriesList);// Count == 4, Capacity == 4;

            //countriesList.Insert(1, new Country { Name = "Jordan", ISOCode = "JOR" }); // this index now is 1 and Brazil Index now is 2
            //Country.Print(countriesList);// Count == 5, Capacity == 8;

            //countriesList.RemoveAt(1);// Jordan will be removed && Brazil Index now is 1
            //Country.Print(countriesList);// Count == 4, Capacity == 8;

            //countriesList.RemoveRange(0, 2);// 1st argument refers to the index u want to start removing from, the 2nd arg refors to the count of elements u want to remove upwards from the index u had given before.
            //Country.Print(countriesList);// Count == 2, Capacity == 8;

            //countriesList.Remove(new Country { Name = "France", ISOCode = "FRA" });// in this case the it will not be removed at runtime because this doesnot refer to XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            ////To make it work u have to override both Equals() && GetHashCode() as we have already done.
            //Country.Print(countriesList);// Count == 1, Capacity == 8;

            //countriesList.RemoveAll(x => x.Name.EndsWith("q"));// this method uses The generic delegate Predicate which allows us to have a logical answer "true" or "false" based on our given condition.
            //// In this case this method will remove all elements in our list which its name EndsWith Letter "q"
            //Country.Print(countriesList);// Count == 0, Capacity == 8;
            #endregion
            #region Dictionaries
            //var article =
            //    "Dot NET is a free cross-platform and open source developer platform " +
            //    "for building many different types of applications " +
            //    "With Dot NET you can use multiple languages and libraries " +
            //    "to build for web and IoT";
            //Dictionaries.Sort(article);
            //Dictionaries.Print();
            #endregion

            var emps = new List<Employee>
            {
                new Employee {Id = 100, Name = "Reem S.", ReportTo = null},
                new Employee {Id = 101, Name = "Raed M.", ReportTo = 100 },
                new Employee {Id = 102, Name = "Ali B.", ReportTo = 100 },
                new Employee {Id = 103, Name = "Abeer S.", ReportTo = 102 },
                new Employee {Id = 104, Name = "Radwan N.", ReportTo = 102 },
                new Employee {Id = 105, Name = "Nancy R.", ReportTo = 101 },
                new Employee {Id = 106, Name = "Saleh A.", ReportTo = 104 }
            };

            //var managers = emps.GroupBy(x => x.ReportTo);
            var managers = emps.ToLookup(x => x.ReportTo).ToDictionary(x => x.Key ?? -1, x => x.ToList());

            foreach (var entry in managers)
            {
                if (entry.Key == -1)
                    continue;
                var manager = emps.FirstOrDefault(x => x.Id == entry.Key);

                Console.WriteLine($"{manager}");

                foreach (var emp in entry.Value)
                {
                    Console.WriteLine($"\t\t\"{emp}\"");
                }
            }

            Console.ReadKey();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReportTo { get; set; }

        public override string ToString()
        {
            return $"[{Id}] -- [{Name}]";
        }
    }
}