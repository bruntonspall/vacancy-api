using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VacancyWeb.Models
{
    public class Location
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}
