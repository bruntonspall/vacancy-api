using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MvcApplication1.Controllers;


namespace MvcApplication1.Models
{
    public class VacancyRepository
    {
        static readonly public VacancyRepository repo = new VacancyRepository();

        private MongoDatabase database;
        private MongoCollection coll;
        private VacancyRepository()
        {
            var connectionString = "mongodb://webapp:zifnabblarg@troup.mongohq.com:10089/apprenticeships";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            database = server.GetDatabase("apprenticeships");
            coll = database.GetCollection("vacancy");
        }
        public IEnumerable<Vacancy> GetAll() {
            return coll.FindAllAs<Vacancy>().SetLimit(5);
        }
        public Vacancy Get(string id)
        {
            return coll.FindOneAs<Vacancy>(Query.EQ("id", id));
        }
        public IEnumerable<Vacancy> Search(string text)
        {
            return coll.FindAs<Vacancy>(Query.In("search", new BsonArray(text.Split().Select((w) => w.Trim(" ,;:.\"\'\\".ToCharArray()).ToLower())))).SetLimit(5);
        }

        public IEnumerable<Vacancy> Nearby(double x, double y, double distance)
        {
            return coll.FindAs<Vacancy>(Query.Near("location", x, y , distance, true)).SetLimit(5);
        }

        public LinesAndCount UpdateSearchTerms()
        {
            var count = 0;
            var lines = new List<String>();
            foreach (Vacancy v in coll.FindAs<Vacancy>(Query.NotExists("search")).SetLimit(1000)) {
                var s = String.Format("{0} {1} {2} {3}", v.title, v.description, v.employer, v.provider);
                var words = s.ToLower().Split(' ')
                    .Select((word) => word.Trim(" ,;:.\"\'\\".ToCharArray()))
                    .Distinct();
                var q = Query.EQ("_id",ObjectId.Parse(v.id));
                var up = Update.Set("search", new BsonArray(words));
                lines.Add("Added to " + q + " the update " + up);
                coll.Update(q, up);
                count++;
            }
            return new LinesAndCount() { count = count, lines = lines.ToArray() };
        }

    }
}
