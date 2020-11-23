using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplicationWebApi.Models;

namespace WebApplicationWebApi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<employee> listofemp = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:30118/api/emp");

            var readData = hc.GetAsync("emp");
            readData.Wait();

            var consumeData = readData.Result;
            if (consumeData.IsSuccessStatusCode)
            {
                var display = consumeData.Content.ReadAsAsync<List<employee>>();
                display.Wait();
                listofemp = display.Result;
                
            }
            ViewBag.employee = listofemp;
            ViewBag.empl = new SelectList(listofemp,"Id","Name");
            TempData["msg"] = listofemp;
            ViewData["msg"] = listofemp;
            return View(listofemp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee emp)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:30118/api/emp");

            var insertdata = hc.PostAsJsonAsync<employee>("emp", emp);
            insertdata.Wait();

            var savedata = insertdata.Result;
            if (savedata.IsSuccessStatusCode)
            {
                ViewBag.msg = "inserted";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            employee emp = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:30118/api/emp");

            var readData = hc.GetAsync("emp?id=" + id.ToString());
            readData.Wait();

            var consumedata = readData.Result;
            if (consumedata.IsSuccessStatusCode)
            {
                var display = consumedata.Content.ReadAsAsync<employee>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:30118/api/emp");

            var insertdata = hc.PutAsJsonAsync<employee>("emp", emp);
            insertdata.Wait();

            var savedata = insertdata.Result;
            if (savedata.IsSuccessStatusCode)
            {
                ViewBag.msg = "inserted";
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public ActionResult Details(int id)
        {
            employee emp = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:30118/api/emp");

            var readData = hc.GetAsync("emp?id=" + id.ToString());
            readData.Wait();

            var consumedata = readData.Result;
            if (consumedata.IsSuccessStatusCode)
            {
                var display = consumedata.Content.ReadAsAsync<employee>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
       
    }
}