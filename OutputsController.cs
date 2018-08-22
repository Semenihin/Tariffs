using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pcar21.Models;

namespace Pcar21.Controllers
{
    public class OutputsController : Controller
    {
        private Pcar21Context db = new Pcar21Context();


        // GET: Outputs/Details/5
        //public ActionResult Details(int? id
        public ActionResult Details(Output output)
        {
            return View(output);
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
