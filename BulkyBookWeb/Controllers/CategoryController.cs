using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.Diagnostics;

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
        //GET
        /* when someone hits the create btn then give them option to enter their name and displayOrder and create a category*/
        /* When View is loaded we do not have to pass any model */
        public IActionResult Create()
        {
            return View();
        }

        // post
        [HttpPost]
        /*this token helps to prevent the cross site request forgery attack
         it automatically inject a key there that key would valide at the step*/
        [ValidateAntiForgeryToken] 
        public IActionResult Create (Category obj)
        {
            /*custom error*/
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                /*AddModelError take parameter in key value pair (CustomError is key and "The Display cannot exactly match the name" is value*/
                ModelState.AddModelError("CustomError", "The Display cannot exactly match the name");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();    /*at this point data goes to database and saves all the changes  */
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");        /*once changes are saved we return the view*/
            }
            return View(obj);
            
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  single throw exception if element not found and singleordefalt dont throw exception if element not found
            //  first th`row exception if more than 1 element found and firstordefault dont throw exception if more than 1 element
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u .Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]
        /*this token helps to prevent the cross site request forgery attack
         it automatically inject a key there that key would valide at the step*/
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            /*custom error*/
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                /*AddModelError take parameter in key value pair (CustomError is key and "The Display cannot exactly match the name" is value*/
                ModelState.AddModelError("CustomError", "The Display cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); // update the object based on ID 
                _db.SaveChanges();    /*at this point data goes to database and saves all the changes  */
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");        /*once changes are saved we return the view*/
            }
            return View(obj);

        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  single throw exception if element not found and singleordefalt dont throw exception if element not found
            //  first throw exception if more than 1 element found and firstordefault dont throw exception if more than 1 element
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u .Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // post
        [HttpPost]
        /*this token helps to prevent the cross site request forgery attack
         it automatically inject a key there that key would valide at the step*/

        //'CategoryController' already defines a member called 'Delete' with the same parameter 

        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj =_db.Categories.Find(id); 
            
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
