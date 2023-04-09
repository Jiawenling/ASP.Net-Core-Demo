using System;
using Demo.Data;
using Demo.Models;

namespace Demo.Repository
{
	public class CategoryRepository: Repository<Category>, ICategoryRepository
	{
        private ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db): base(db)
		{
            _db = db;
		}

        void ICategoryRepository.Save()
        {
            _db.SaveChanges();
        }

        void ICategoryRepository.Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}

