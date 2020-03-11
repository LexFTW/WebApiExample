using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFrameworkDatabase;

namespace WebApiExample.Controllers
{
    public class StudentsController : ApiController
    {

        private VuelingEntities vuelingEntities = new VuelingEntities();

        [HttpPost]
        public IHttpActionResult Add()
        {
            Students student = new Students();
            student.Name = "Postman";
            vuelingEntities.Students.Add(student);
            return Ok(Get());
        }

        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return vuelingEntities.Students.ToList();
        }
    }
}
