using System;
using System.Collections.Generic;

namespace LoopRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User
                {
                    Birth = new DateTime(1990, 11, 5),
                    Id = 1,
                    EmailAddress = "user1@test.com"
                },
                new User
                {
                    Birth = new DateTime(1990, 11, 22),
                    Id = 2,
                    EmailAddress = "user2@test.com"
                },
                new User
                {
                    Birth = new DateTime(1990, 4, 27),
                    Id = 3,
                    EmailAddress = "user3@test.com"
                }
            };

            var orders = new List<Order>
            {
                new Order
                {
                    Amount = 1000,
                    Buyer = users[0],
                    Id = "12345",
                },
                new Order
                {
                    Amount = 7000,
                    Buyer = users[2],
                    Id = "23456",
                },
                new Order
                {
                    Amount = 560,
                    Buyer = users[1],
                    Id = "34567",
                },
                new Order
                {
                    Amount = 780,
                    Buyer = users[0],
                    Id = "45678",
                },
                new Order
                {
                    Amount = 65,
                    Buyer = users[2],
                    Id = "56789",
                }
            };
            
            GroupJoin.GroupJoinFunction(users, orders);
        }
    }
}