using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookShopModel
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
