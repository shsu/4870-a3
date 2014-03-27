using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using backend.Models.Entity;
using backend.DAL;

namespace backend.Controllers.MVC
{
    public class ChoiceAdminController : Controller
    {
        private OptionSelectionContext db = new OptionSelectionContext();

        // GET: /ChoiceAdmin/
        public ActionResult Index()
        {
            var choices = db.Choices.Include(c => c.FirstOptionChoice).Include(c => c.ForthOptionChoice).Include(c => c.SecondOptionChoice).Include(c => c.Term).Include(c => c.ThirdOptionChoice);
            return View(choices.ToList());
        }

        // GET: /ChoiceAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // GET: /ChoiceAdmin/Create
        public ActionResult Create()
        {
            ViewBag.FirstOptionChoiceId = new SelectList(db.Options, "Id", "Title");
            ViewBag.ForthOptionChoiceId = new SelectList(db.Options, "Id", "Title");
            ViewBag.SecondOptionChoiceId = new SelectList(db.Options, "Id", "Title");
            ViewBag.TermId = new SelectList(db.Terms, "Id", "Description");
            ViewBag.ThirdOptionChoiceId = new SelectList(db.Options, "Id", "Title");
            return View();
        }

        // POST: /ChoiceAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StudentNumber,FirstName,LastName,TermId,FirstOptionChoiceId,SecondOptionChoiceId,ThirdOptionChoiceId,ForthOptionChoiceId")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirstOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.FirstOptionChoiceId);
            ViewBag.ForthOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ForthOptionChoiceId);
            ViewBag.SecondOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.SecondOptionChoiceId);
            ViewBag.TermId = new SelectList(db.Terms, "Id", "Description", choice.TermId);
            ViewBag.ThirdOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ThirdOptionChoiceId);
            return View(choice);
        }

        // GET: /ChoiceAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.FirstOptionChoiceId);
            ViewBag.ForthOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ForthOptionChoiceId);
            ViewBag.SecondOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.SecondOptionChoiceId);
            ViewBag.TermId = new SelectList(db.Terms, "Id", "Description", choice.TermId);
            ViewBag.ThirdOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ThirdOptionChoiceId);
            return View(choice);
        }

        // POST: /ChoiceAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StudentNumber,FirstName,LastName,TermId,FirstOptionChoiceId,SecondOptionChoiceId,ThirdOptionChoiceId,ForthOptionChoiceId")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirstOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.FirstOptionChoiceId);
            ViewBag.ForthOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ForthOptionChoiceId);
            ViewBag.SecondOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.SecondOptionChoiceId);
            ViewBag.TermId = new SelectList(db.Terms, "Id", "Description", choice.TermId);
            ViewBag.ThirdOptionChoiceId = new SelectList(db.Options, "Id", "Title", choice.ThirdOptionChoiceId);
            return View(choice);
        }

        // GET: /ChoiceAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: /ChoiceAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
