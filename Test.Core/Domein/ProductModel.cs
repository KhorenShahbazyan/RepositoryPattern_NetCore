using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core.Domein
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
    }
}
