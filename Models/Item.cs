using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCFD.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Category { get; set; }
        //public double Amount { get; set; }
        public int Item_TransId { get; set; }
    }
}