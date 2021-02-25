using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Models;

namespace UsersManagement.API.Dummy
{
    public static class DummyData
    {
        private static List<User> _users;
        public static List<User> GetUsers(int dataSize)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                   .RuleFor(user => user.Id, faker => faker.IndexFaker + 1)
                   .RuleFor(user => user.Firstname, faker => faker.Name.FirstName())
                   .RuleFor(user => user.Lastname, faker => faker.Name.LastName())
                   .RuleFor(user => user.Address, faker => faker.Address.FullAddress())
                   .Generate(dataSize);
            }
            return _users;
        }
    }
}
