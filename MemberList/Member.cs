namespace MemberList
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public Member(string firstname, string lastname, int age)
        {
            FirstName = firstname;
            LastName = lastname;    
            Age = age;
        }
        public Member()
        {

        }
    }
}
