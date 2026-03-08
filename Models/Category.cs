using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebsite.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
