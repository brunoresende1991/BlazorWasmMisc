using System;
using System.Collections.Generic;

namespace BlazorWasm.Server.Models
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Quantity { get; set; }
        public int Price { get; set; }
        public bool? Available { get; set; }
    }
}
