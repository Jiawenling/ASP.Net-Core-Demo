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
        public async IActionResult Index()
        {
            await _db.OpenAsync();

            using var command = new MySqlCommand("SELECT field FROM table;", _db);
            using var reader = await command.ExecuteReaderAsync();
            List<Category> categories = new List<Category>();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                // do something with 'value'
            }
            return View();
        }
    }
}

