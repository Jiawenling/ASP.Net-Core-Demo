using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
	public class Category
	{
		public int Id { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}

