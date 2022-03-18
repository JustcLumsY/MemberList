using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MemberList
{
    public class Display
    {      
        public static void Run()
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
             ShowNewMember(newMember);
             Run();
        }

        private static void ShowNewMember(Member newMember)
        {
            Console.Clear();
            Console.WriteLine("You added");
            Console.WriteLine("---------");
            Console.WriteLine($"FirstName: {newMember.FirstName}");
            Console.WriteLine($"LastName: {newMember.LastName}");
            Console.WriteLine($"Age: {newMember.Age}");
            Console.ReadLine();
        }

        private static void GetList()
        {
            Console.Clear();
            Console.WriteLine("Press 'c' to get the List or Enter to add new member");
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
                DeleteAMember(list);
                GetList();
            }
        }

        private static void DeleteAMember(List<Member> list)
        {
            Console.WriteLine("Write the name of who you want to delete");
            var userInput = Console.ReadLine();
            var people = list.FirstOrDefault(x => x.FirstName.ToLower() == userInput.ToLower());
            Console.WriteLine($"Are you sure you want to delete: {people.FirstName}?");
            Textcolor(ConsoleColor.Red);
            Console.WriteLine("               YES/NO");
            Textcolor(ConsoleColor.White);
            userInput = Console.ReadLine();
            if (userInput == "YES".ToLower()) 
            {
                Textcolor(ConsoleColor.Red);
                list.Remove(people);
                Console.WriteLine($"Removed: {people.FirstName}");
                JsonHandler.WriteToJson(list);
                Console.ReadLine();
                Textcolor(ConsoleColor.White);
            }
            else if(userInput == "NO".ToLower()) 
            { 
                 Textcolor(ConsoleColor.White);
                 userInput = "";
                 Console.Clear();
                 Run();
            }                         
        }
        public static void Textcolor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
