using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace luce_MIS4200_1045.Models
{
    public class customer
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Display(Name="Mobil Phone")]
        public string phone { get; set; }
        public string email { get; set; }
        [Display(Name ="Customer Name")]
        public string fullName { get
            {
                return lastName + ", " + firstName;
            } }
        public ICollection<customerOrder> customerOrder { get; set; }
    }
}