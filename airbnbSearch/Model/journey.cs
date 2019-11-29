using System;
using System.Collections.Generic;
using System.Text;

namespace airbnbSearch.Model
{
    public class journey
    {
        public int id { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
