using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;
using System.Data.Entity;

namespace DotNetExpress.Repository.Repository
{
    public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Category category)
        {
            _dbContext.categories.Add(category);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Category acategory = _dbContext.categories.FirstOrDefault((c => c.Id == id));
            _dbContext.categories.Remove(acategory);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Category category)
        {
            Category acategory = _dbContext.categories.FirstOrDefault(c => c.Id == category.Id);
            if (acategory != null)
            {
                acategory.Code = category.Code;
                acategory.Name = category.Name;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            var categories = _dbContext.categories.ToList();
            foreach (var category in categories)
            {
                //All
                _dbContext.Entry(category).Collection(c => c.Products).Load();

                //Query
                _dbContext.Entry(category)
                    .Collection(c => c.Products)
                    .Query()
                    .Where(c => c.Name.Contains("l"))
                    .Load();

            }
            return categories;
        }
        public Category GetById(int id)
        {

            return _dbContext.categories.FirstOrDefault((c => c.Id == id));
        }
    }
}
