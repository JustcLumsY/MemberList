using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MemberList
{
    internal class Display
    {      
        public static async Task AddMember()
        {
            GetList();
            Addnewmember();
        }

        private static void Addnewmember()
        {
            Console.Clear();
            //Henter mainList Json (med alle medlemene)
            var mainList = JsonHandler.GetListFromJson();
            Console.WriteLine("Enter FirstName");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Age");
            var age = Convert.ToInt32(Console.ReadLine());

            var newMember = new Member(firstName, lastName, age);

            //Adder ny member til MainListen<>
             mainList.Add(newMember); 
             JsonHandler.WriteToJson(mainList);    
        }

        private static void GetList()
        {
            Console.Clear();
            Console.WriteLine("Press c to get List or Enter to add new member");
            var checkMemberList = Console.ReadLine();
            if (checkMemberList == "c")
            {
            var list = JsonHandler.GetListFromJson();

                foreach (var item in list)
                {
                    Console.WriteLine(item.FirstName);
                    Console.WriteLine(item.LastName);
                    Console.WriteLine(item.Age);
                    Console.WriteLine("-----");
                }

                Console.WriteLine("Write the name of who you want to delete");
                var userInput = Console.ReadLine();
                var people = list.FirstOrDefault(x => x.FirstName.ToLower() == userInput.ToLower()) ;
                list.Remove(people);
                Console.WriteLine($"Removed: {people.FirstName}");
                JsonHandler.WriteToJson(list);
                Thread.Sleep(1500);
                GetList();
            }        
        }
    }
}
