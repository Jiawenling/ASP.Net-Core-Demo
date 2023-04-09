using System;
using Demo.Models;

namespace Demo.Repository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category obj);
		void Save();
	}
}

