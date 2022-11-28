using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Models
{
    public class Product
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public string description { get; set; }
        public string photoUrl { get; set; }
        public long? price { get; set; }
        public long? amount { get; set; }
        public string userId { get; set; }
    }
}
