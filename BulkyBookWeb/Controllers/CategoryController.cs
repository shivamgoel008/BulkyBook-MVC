using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        /*this db (neeche vala) have all the implementation of connection strings and table that are needed to retrive*/
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;// now we can use this _db to retrive all the categories 
        }
        public IActionResult Index()
        {
           /* so it go to database, it will retrive all of the categories and
            convert to a list and it will assign that inside the varibale objCategoryList*/ 
            IEnumerable<Category> objCatetoryList = _db.Categories.ToList();

            // passing our category list to our view and need to capture in our view 
            return View(objCatetoryList);
        }
    }
}
