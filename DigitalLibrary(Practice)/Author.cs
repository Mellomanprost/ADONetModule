using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Practice
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public List<Book>? Books { get; set;  } = new List<Book>();
    }
}
