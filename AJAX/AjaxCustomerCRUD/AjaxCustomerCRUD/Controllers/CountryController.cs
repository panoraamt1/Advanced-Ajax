using AjaxCustomerCRUD.Data;
using AjaxCustomerCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AjaxCustomerCRUD.Controllers
{
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Customer> countries;
            countries = _context.Countries.ToList();
            return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer country = new Customer();
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Customer country)
        {
            _context.Add(country);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            Customer country = GetCountry(Id);
            return View(country);
        }

        [HttpGet]

        public IActionResult Edit(int Id)
        {
            Customer country = GetCountry(Id);
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public IActionResult Edit(Customer country)
        {
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Customer GetCountry(int id)
        {
            Customer country;
            country = _context.Countries
                .Where(c => c.Id == id).FirstOrDefault();
            return country;
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            Customer country = GetCountry(id);
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public IActionResult Delete(Customer country)
        {
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

