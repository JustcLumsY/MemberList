using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberList
{
    internal class Display
    {      
        public static async Task AddMember()
        {
            
            //Henter mainList Json (med alle medlemene)
            var mainList = JsonHandler.GetListFromJson();
            GetList();
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
            Console.WriteLine("Press c to get List");
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
            }
        }
    }
}
