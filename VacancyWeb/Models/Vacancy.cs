using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacancyWeb.Models
{
    public class Vacancy
    {

        public string id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string reference { get; set; }
        public string employer { get; set; }
        public string provider { get; set; }
        public string employer_url { get; set; }
        public Location location { get; set; }
        public string address { get; set; }
        public string hours { get; set; }
        public string wage_weekly { get; set; }
        public int position_count { get; set; }
        public DateTime closing_date { get; set; }
        public DateTime interview_date_start { get; set; }
        public DateTime position_start_date { get; set; }
        public string training { get; set; }
        public string vacancy_type { get; set; }
        public string duration { get; set; }
        public string qualifications_required { get; set; }
        public string description { get; set; }
        public string skills_required { get; set; }
        public List<string> search { get; set; }
    }
}