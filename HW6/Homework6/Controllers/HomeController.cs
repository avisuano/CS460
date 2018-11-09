using System.Linq;
using System.Web.Mvc;
using Homework6.Models;
using Homework6.Models.Required;

namespace Homework6.Controllers
{
    /// <summary>
    /// Controller to find customers in the database.
    /// </summary>
    public class HomeController : Controller
    {
        // Initialize the database
        WideWorldImportersEntity db = new WideWorldImportersEntity();

        // GET: go find the submitted string
        public ActionResult Customer(string searchResults)
        {

            // Quick check to make sure something is actually passed
            if (searchResults == null || searchResults == "")
            {
                ViewBag.Customer = false;
                return View();
            }
            // The first doozy to crack.
            else
            {
                ViewBag.Customer = true;
                return View(db.People.Where(a => a.FullName.ToUpper().Contains(searchResults.ToUpper())).ToList());
            }            
        }

        // Go grab details for the customer object selected
        public ActionResult Details(int? id)
        {
            // First step is to pass the required model class into a new instance
            WWViewModel vmd = new WWViewModel { GetPerson = db.People.Find(id) };
            ViewBag.Found = false;

            // Make sure to only pass if there is actually something there
            if (vmd.GetPerson.Customers2.Count() > 0)
            {
                ViewBag.Found = true;
                // Uses the required model to grab the customers ID and begin digging through the database
                int GetCustomerID = vmd.GetPerson.Customers2.FirstOrDefault().CustomerID;
                vmd.GetCustomer = db.Customers.Find(GetCustomerID);

                // The real problem child of the assignment without LINQPad it was mostly trial and error
                ViewBag.GrossSales = vmd.GetCustomer.Orders.SelectMany(b => b.Invoices).SelectMany(c => c.InvoiceLines).Sum(d => d.ExtendedPrice);
                ViewBag.GrossProfit = vmd.GetCustomer.Orders.SelectMany(e => e.Invoices).SelectMany(f => f.InvoiceLines).Sum(g => g.LineProfit);
                vmd.GetInvoiceLine = vmd.GetCustomer.Orders.SelectMany(h => h.Invoices).SelectMany(i => i.InvoiceLines).OrderByDescending(j => j.LineProfit).Take(10).ToList();
            }

            // If nothing is found
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            // This is to pass the view model to the browser
            return View("Details",vmd);
        }
    }
}