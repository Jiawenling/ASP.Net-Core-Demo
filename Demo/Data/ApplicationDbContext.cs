using System;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
	public class ApplicationDbContext: DbContext
	{
		//static readonly string connectionString = "Server=localhost;User ID=root;Password=;Database=Bulky";

		//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//      {
		//          optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
		//      }
		public ApplicationDbContext(DbContextOptions options):base(options)
		{
				
		}
        public virtual DbSet<Category> Categories { get; set; }
	}
}

 