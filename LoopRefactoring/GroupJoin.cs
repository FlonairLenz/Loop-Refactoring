using System;
using System.Collections.Generic;
using System.Linq;

namespace LoopRefactoring
{
    public class GroupJoin
    {
        public static void GroupJoinFunction(IList<User> users, IList<Order> orders)
        {
            var query = users
                .Where(user => user.Birth.Month == DateTime.Now.Month)
                .GroupJoin(orders,
                    user => user,
                    order => order.Buyer,
                    (user, orders) => new
                    {
                        UserEmailAdress = user.EmailAddress,
                        Orders = orders
                    }
                )
                .Where(userOrders => userOrders.Orders.Count() >= 2);

            foreach (var userOrder in query)
            {
                Console.WriteLine(userOrder.UserEmailAdress);
                foreach (var order in userOrder.Orders)
                {
                    Console.WriteLine($"\t{order.Id}: {order.Amount}");
                }
            }
        }
    }

    public class User : IComparable<User>
    {
        public DateTime Birth { get; set; }
        public string EmailAddress { get; set; }
        public int Id { get; set; }

        public int CompareTo(User other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var birthComparison = Birth.CompareTo(other.Birth);
            if (birthComparison != 0) return birthComparison;
            var emailAddressComparison = string.Compare(EmailAddress, other.EmailAddress, StringComparison.Ordinal);
            if (emailAddressComparison != 0) return emailAddressComparison;
            return Id.CompareTo(other.Id);
        }
    }

    public class Order
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public User Buyer { get; set; }
    }
}