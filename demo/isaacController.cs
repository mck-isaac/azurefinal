using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isaacService.Controllers
{

    class Cause
    {
        public String Year { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        public String Deaths { get; set; }
        public String Age { get; set; }
    }
   [Route("api/[Controller]")] 
    public class isaacController : Controller
    {

        List<Cause> causes = new List<Cause>();

        public IActionResult IndexIsaac()
        {
            var fileName = @"NCHS_-_Leading_Causes_of_Death__United_States.csv";
            var file = System.IO.File.ReadLines(fileName).ToList();
            int count = file.Count();
            Random rnd = new Random();
            int skip = rnd.Next(0, count);
            string line = file.Skip(skip).First();
            String[] contents = line.Split('|');

            Cause cause = new Cause()
            {
                Year = contents[0],
                Name = contents[2],
                State = contents[3],
                Deaths = contents[4],
                Age = contents[5]
            };

            causes.Add(cause);

            return new JsonResult(causes);
        }

        // GET: isaac
        public ActionResult Index()
        {
            return View();
        }

        // GET: isaac/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: isaac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: isaac/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: isaac/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: isaac/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: isaac/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: isaac/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}