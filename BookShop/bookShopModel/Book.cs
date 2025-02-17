using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bookShopModel
{
    public class Book
    {
        [Key]
        public int Id;
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
