using AuctionSystem.Entities;
using AuctionSystem.Services;
using AuctionSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        
        CategoryService categoryService = new CategoryService();
        
        public ActionResult Index()
        {
            CategorysListViewModel model = new CategorysListViewModel();
            model.Categories = categoryService.GetAllCategories();
            model.PageTitle = "Create new category";
            model.PageDescription = "This is an page for creating a new category";
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
       public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            Category category = new Category();
            category.Name = model.Name;
            category.Description = model.Description;

            categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            CategoryViewModel model = new CategoryViewModel();
            var category = categoryService.GetCategoryId(Id);
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
           return PartialView(model);

        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            Category Category = new Category();
            Category.Id = model.Id;
            Category.Name = model.Name;
            Category.Description = model.Description;
            categoryService.UpdateCategory(Category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var category = categoryService.GetCategoryId(Id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoryService.DeleteCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            CategoryDetailViewModel model = new CategoryDetailViewModel();

            model.Category = categoryService.GetCategoryId(Id);
           /* model.PageTitle = "Auction Details"+model.Category.Name;
            model.PageDescription = "This is auction Detail page";*/
            return View(model);
        }
    }
}