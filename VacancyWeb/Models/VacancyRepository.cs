using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using RestSharp.Contrib;
using System.Configuration;

namespace VacancyWeb.Models
{
    public class VacancyRepository
    {
        public static readonly VacancyRepository repo = new VacancyRepository();
        public VacancyRepository()
        {

        }

        public IEnumerable<Vacancy> LatestVacancies()
        {
            return getLatestVacancies();
        }

        private IEnumerable<Vacancy> getLatestVacancies()
        {
            RestRequest request = new RestRequest("/search");
            request.RequestFormat = DataFormat.Xml;
            return execute<List<Vacancy>>(request);
        }
        private T execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = ConfigurationManager.AppSettings["api-base-url"];

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var e = new ApplicationException(message, response.ErrorException);
                throw e;
            }
            return response.Data;
        }
    }
}
