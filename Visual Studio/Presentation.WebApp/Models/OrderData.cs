using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.WebApp.Models
{
    public class OrderData
    {
        public string cityValue { get; set; }
        public string streetValue { get; set; }
        public int housenumber { get; set; }
        public double paymentValue { get; set; }
        public int priorityValue { get; set; }
    }
}