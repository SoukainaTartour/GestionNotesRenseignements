using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CasaNR.Models;

namespace CasaNR.Controllers
{
    public class NRs1Controller : Controller
    {
        private CasaNREntities db = new CasaNREntities();

        // GET: NRs1
       

        public ActionResult Index(string etat, string IdNR)
        {
            var nrs = db.NR.ToList();
            if (!String.IsNullOrEmpty(etat))
            {
                nrs = db.NR.Where(x => x.Etat.Contains(etat)).ToList();
            }
            if (!String.IsNullOrEmpty(IdNR))
            {
                nrs = db.NR.Where(x => x.NR_Id.Contains(IdNR)).ToList();
            }


            return View(nrs);
        }

        public ActionResult Stat()
        {
            int delivre = db.NR.Where(x => x.Etat == "Delivre").Count();
            int nontraite = db.NR.Where(x => x.Etat == "Non traite").Count();
            int encours = db.NR.Where(x => x.Etat == "En cours de traitement").Count();
            Ratio obj = new Ratio();
            obj.Delivre = delivre;
            obj.NonTraite = nontraite;
            obj.EnCours = encours;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int Delivre { get; set; }
            public int NonTraite { get; set; }
            public int EnCours { get; set; }
        }

        public ActionResult Chart()
        {
            return View();
        }
         public ActionResult ChartNR()
        {
            return View();
        }
        
        // GET: NRs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NR.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }


        // GET: NRs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NRs1/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OBJECTID,Reference_,Prenom,Societe,Qualite,Nature_ter,Zonage,indice_Equ,Voirie,Autres,NR_Id,Etat,SHAPE_STAr,SHAPE_STLe,SHAPE")] NR nR)
        {
            if (ModelState.IsValid)
            {
                db.NR.Add(nR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nR);
        }

        // GET: NRs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NR.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }

        // POST: NRs1/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OBJECTID,Reference_,Prenom,Societe,Qualite,Nature_ter,Zonage,indice_Equ,Voirie,Autres,NR_Id,Etat,SHAPE_STAr,SHAPE_STLe,SHAPE")] NR nR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nR);
        }

        // GET: NRs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NR.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }

        // POST: NRs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NR nR = db.NR.Find(id);
            db.NR.Remove(nR);
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
