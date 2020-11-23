using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationWebApi.Models;

namespace WebApplicationWebApi.Controllers
{
    public class EmpController : ApiController
    {
        WebApi db = new WebApi();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
           var list= db.employees.ToList();
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult Insert(employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(employee emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var list = db.employees.Find(id);
            return Ok(list);
        }


    }
}
