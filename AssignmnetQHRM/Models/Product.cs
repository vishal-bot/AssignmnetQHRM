using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AssignmnetQHRM.Models
{
    public class Product
    {
        public int Id { get; set; }


        [Display(Name = "Product")]
        public string ProductName { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
