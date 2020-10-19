using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // VIEW ONE:   GET: https://localhost:44354/movies/Random
        public object Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            // Initialise the Move and Customers properties
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            // Method 1:  Pass data from Controller to View using a ViewDataDictionary  - NOT PREFERABLE WAY
            // ViewData["Movie"] = movie; // using this method, remove movie from return View(movie) below

            // Method 2: Pass data from Controller to View using a ViewBag   - NOT PREFERABLE WAY
            // ViewBag.Movie = movie;

            // Method 3:  Pass data from Controller to View using a ViewData - preferable way
            //var ViewResult = new ViewResult();
            //_ = ViewResult.ViewData.Model;

            

            return View(viewModel);
            // return Content("Hello World!");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        // VIEW CUSTOM ROUTE:  https://localhost:44354/movies/released/2015/4 (make sure this is configured in RouteConfig)
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]  // Applying attribute routing as setup in RouteConfig - month must be two digits and between 1 - 12
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // VIEW TWO:   GET:  https://localhost:44354/movies/edit/1
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // VIEW THREE
        // GET:  https://localhost:44354/movies  RETURN A VIEW CONTAINING A LIST OF MOVIES SPANNING MULTIPLE WEBPAGES. OPTIONAL PARAMETERS: PAGE INDEX AND SORTBY 
        public ActionResult Index(int? pageIndex, string sortBy) // THESE SHOULD BE NULLIBLE... THE QUESTION MARK CONVERTS THE INT TO NULLIBLE
        {
            if (!pageIndex.HasValue) // IF PAGE IS NOT SPECIFIED BY USER, BY DEFAULT SHOW PAGE 1
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy)) //  IF SORT METHOD IS NOT SELECTED BY USER SHOW MOVIES IN ALPHABETICAL ORDER
                sortBy = "Name";

            // 
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}