using System;
using System.Collections.Generic;

namespace CoffeeShopWebsite.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
