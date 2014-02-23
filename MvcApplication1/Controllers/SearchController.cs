using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SearchController : ApiController
    {
        static readonly VacancyRepository repo = new VacancyRepository();
        public IEnumerable<Vacancy> GetAllSearchResults()
        {
            return repo.GetAll();          
        }

        public IEnumerable<Vacancy> Get(string text)
        {
            return repo.Search(text);
        }
    }
}
