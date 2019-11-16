using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Repository.Repository
{
    public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Category category)
        {
            int i = _dbContext.categories.Where(c => c.Code == category.Code).Count();
            {
                if (i > 0)
                {
                    return false;
                }
                _dbContext.categories.Add(category);
                return _dbContext.SaveChanges() > 0;
            }
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
            return _dbContext.categories.ToList();
        }
        public Category GetById(int id)
        {

            return _dbContext.categories.FirstOrDefault((c => c.Id == id));
        }
    }
}
