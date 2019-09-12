using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luce_MIS4200_1045.Models
{
    public class lineItem
    {
        public int ID { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
        public virtual customerOrder customerOrder { get; set; }
        public virtual product product { get; set; }
    }
}