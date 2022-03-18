using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberList
{
    public class App
    {      
        public static void Run()
        {
            GetList();
            Addnewmember();
        }

        private static void Addnewmember()
        {
            Console.Clear();
            //Henter mainList Json (med alle medlemmene)
            var mainList = JsonHandler.GetListFromJson();
            string firstName, lastName;
            Member newMember;
            AddFirstNameLastNameandAge(out firstName, out lastName, out newMember);
            CheckIfUsernameExist(firstName, lastName);
            //Adder ny member til MainListen<>
            mainList.Add(newMember);
            JsonHandler.WriteToJson(mainList);
            //Viser member som ble lagt til
            ShowNewMember(newMember);
            Run();
        }

        private static void AddFirstNameLastNameandAge(out string firstName, out string lastName, out Member newMember)
        {
            Console.WriteLine("Enter FirstName");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter Age");
            var age = Convert.ToInt32(Console.ReadLine());
            newMember = new Member(firstName, lastName, age);
        }

        private static void CheckIfUsernameExist(string firstname, string lastname)
        {
            var test = JsonHandler.GetListFromJson();
            foreach (var user in test)
            {
                if (user.FirstName == firstname && user.LastName == lastname)
                {
                    Console.Clear();
                    Console.WriteLine("FirstName and LastName exist. Try again");
                    Console.ReadLine();
                    Run();
                }
            }
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
                Console.Clear();
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
            Console.WriteLine("Write the name of who you want to delete | R to return");
            var userInput = Console.ReadLine();
            if (userInput == ""){ DeleteAMember(list); }
            if (userInput == "R".ToLower()){ Run(); }

            var people = list.FirstOrDefault(x => x.FirstName.ToLower() == userInput.ToLower());
            Console.WriteLine($"Are you sure you want to delete: {people.FirstName}?");
            Textcolor(ConsoleColor.Red);
            Console.WriteLine("               YES/NO");
            Textcolor(ConsoleColor.White);
            userInput = Console.ReadLine();
            if (userInput == "YES".ToLower()){ RemoveMember(list, people); Run(); }
            else if(userInput == "NO".ToLower())  
            { 
                 Textcolor(ConsoleColor.White);
                 userInput = "";
                 Run();
            }                         
        }

        private static void RemoveMember(List<Member> list, Member people)
        {
            Textcolor(ConsoleColor.Red);
            list.Remove(people);
            Console.WriteLine($"Removed: {people.FirstName}");
            JsonHandler.WriteToJson(list);
            Console.ReadLine();
            Textcolor(ConsoleColor.White);
        }

        public static void Textcolor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
