using System;
using System.Collections.Generic;

namespace  pesazangu.Models
{
    //our vendor
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}