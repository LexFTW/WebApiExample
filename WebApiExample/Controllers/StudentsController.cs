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
            var result = vuelingEntities.Students.Add(student);
            vuelingEntities.SaveChanges();
            return Ok(result);
        }

        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return vuelingEntities.Students.ToList();
        }

        [HttpPut]
        public IHttpActionResult Update()
        {
            var student = vuelingEntities.Students.Find(1);
            student.Name = "Update";
            vuelingEntities.SaveChanges();
            return Ok(Get());
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {
            vuelingEntities.Students.Remove(vuelingEntities.Students.Find(1));
            vuelingEntities.SaveChanges();
            return Ok(Get());
        }
    }
}
