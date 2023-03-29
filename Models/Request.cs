using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Request
    {
        public string FoodName { get; set; }
        public string FoodRequestID { get; set; }

        public int Quantity { get; set; }
        public string PostStatus { get; set; }

        public string Location { get; set; }

        public string AssingedEmployee { get; set; }

        public string ResturantID { get; set; }

    }
}