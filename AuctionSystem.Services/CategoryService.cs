using AuctionSystem.Data;
using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class CategoryService
    {
        public List<Category> GetAllCategories()
        {
            DBContext context = new DBContext();
            return context.Categories.ToList();
        }
        public void AddCategory(Category category) {
            DBContext context = new DBContext();
            context.Categories.Add(category);
            context.SaveChanges();

        }
        public Category GetCategoryId(int Id)
        {
            DBContext context = new DBContext();
            return context.Categories.Find(Id);
        }
        public void UpdateCategory(Category category)
        {
            DBContext context = new DBContext();
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            DBContext context = new DBContext();
            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }



    }
}
