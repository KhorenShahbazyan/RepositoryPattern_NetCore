using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core.Domein
{
    public class ShoppingModel
    {
        public long OrderId { get; set; }
        public long ProductOrederId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int Count { get; set; }
    }
}
