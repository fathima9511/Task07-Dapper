using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task07_Dapper.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookPublication { get; set; }
        public int BookYear { get; set; }
        public int BookPrice { get; set; }
     
    }
}