using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        [Route ("Create")]
        public IActionResult Create (QuoteModel newQuote) {
            if (ModelState.IsValid) {
                string query = $"INSERT INTO quotes_and_users (name, quote) VALUES ('{newQuote.Name}','{newQuote.QuoteBody}')";
                DbConnector.Execute(query);
                return RedirectToAction ("Quotes");
            }
            return View ("Index");
        }
        
        [HttpGet]
        [Route ("Quotes")]
        public IActionResult Quotes () {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes_and_users");
            AllQuotes.Reverse();
            ViewBag.Quotes = AllQuotes;
            return View ("Quotes");
        }
    }
}