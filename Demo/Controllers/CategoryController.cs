using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MySqlConnection _db;

        public CategoryController(MySqlConnection connection)
        {
            _db = connection;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            await _db.OpenAsync();

            using var command = new MySqlCommand("SELECT Name from Categories", _db);
            using var reader = await command.ExecuteReaderAsync();
            List<Category> categories = new List<Category>();
            while (await reader.ReadAsync())
            {
                var value = reader.GetFieldValue<string>(0);
                // do something with 'value'
                categories.Add(new Category() { Name = value });
            }
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            await _db.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO Categories (Name, DisplayOrder, CreatedDateTime) VALUES (name, displayOrder, newdate);", _db);
            command.Parameters.AddWithValue("name", category.Name);
            command.Parameters.AddWithValue("displayOrder", category.DisplayOrder);
            command.Parameters.AddWithValue("newdate", DateTime.Now.ToString("yyyy/MM/dd"));

            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                TempData["Success"] = "Successfully Created";
                return RedirectToAction("Index");
            }
            else TempData["Error"] = "Error creating entry";
            return View(category);
        }
    }
}

