using UserManagement.Models;
using Bogus;

namespace UserManagement.Data
{
    public static class Data
    {
        private static List<UserModel> UserList;

        public static List<UserModel> GetUsers(int num)
        {
            if(UserList == null) 
            {
                UserList = new Faker<UserModel>().RuleFor(u => u.Id, f => f.IndexFaker)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .Generate(num);
            }
            
            return UserList;

        }

    }
}
