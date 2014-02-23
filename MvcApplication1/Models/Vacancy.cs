using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Vacancy
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string url;
        public string title;
        public string reference;
        public string employer;
        public string provider;
        public string employer_url;
        public Location location;
        public string address;
        public string hours;
        public string wage_weekly;
        public int position_count;
         [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime closing_date;
         [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime interview_date_start;
         [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime position_start_date;
        public string training;
        public string vacancy_type;
        public string duration;
        public string qualifications_required;
        public string description;
        public string skills_required;
        public string[] search;
    }
}