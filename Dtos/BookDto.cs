using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirtualLibrary.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
    }
}
