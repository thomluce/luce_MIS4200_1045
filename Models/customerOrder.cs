﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luce_MIS4200_1045.Models
{
    public class customerOrder
    {
        public int customerOrderID { get; set; }
        public int customerID { get; set; }
        public virtual customer customer { get; set; }
        public DateTime orderDate { get; set; }
    }
}