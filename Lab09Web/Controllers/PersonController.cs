using Lab09Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab09Web.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {

            if(Session["person"]==null)
            {
                List<Person> person = new List<Person>();
                person.Add(new Person { Id = 1, FirstName = "Lincoln", LastName = "Martinez", BirthDay = DateTime.Today, IsTecsup = false });
                person.Add(new Person { Id = 2, FirstName = "Josue", LastName = "Garay", BirthDay = DateTime.Today, IsTecsup = true });

                Session["person"] = person;
            }
            
            return View(Session["Person"]);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var model = ((List<Person>)Session["person"]).Where(x=>x.Id==id).FirstOrDefault();

            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (Session["person"] == null)
                    Session["person"] = new List<Person>();
                // TODO: Add insert logic here
                ((List<Person>)Session["person"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<Person>)Session["person"]).Where(x => x.Id == id).FirstOrDefault();

            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            try
            {
                // TODO: Add update logic here
                var person = ((List<Person>)Session["person"]).Where(x => x.Id == id).FirstOrDefault();
                person = model;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Person>)Session["person"]).Where(x => x.Id == id).FirstOrDefault();

            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var personIndex = ((List<Person>)Session["person"]).FindIndex(i => i.Id == id);
                ((List<Person>)Session["person"]).RemoveAt(personIndex);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
