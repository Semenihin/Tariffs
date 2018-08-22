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
    public class InputsController : Controller
    {
        private Pcar21Context db = new Pcar21Context();

        // GET: Inputs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PowerConsumption,ReplacementCost")] Input input)
        {
            input.Id = "1";
            if (ModelState.IsValid)
            {
                Output output = new Output();
                output.Id = 1;
                Algorithm algorithm = new Algorithm();
                algorithm.Mid(input.PowerConsumption);
                algorithm.Work(Convert.ToDouble(input.ReplacementCost.Replace('.',',')));
                output.Month = algorithm.Mounth();
                output.Year = algorithm.Year();
                return RedirectToAction("Details", "Outputs", output);
            }

            return View(input);
        }
        
        
    }
}
