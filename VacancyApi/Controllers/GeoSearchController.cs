﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VacancyApi.Models;


namespace VacancyApi.Controllers
{

    public class GeoSearchController : ApiController
    {
        static readonly VacancyRepository repo = VacancyRepository.repo;
        public IEnumerable<Vacancy> GetNear(double x, double y, double radius) {
            return repo.Nearby(x, y, radius);
        }
        public IEnumerable<Vacancy> GetNear(double x, double y)
        {
            return repo.Nearby(x, y, 1.0);
        }
    }
}
