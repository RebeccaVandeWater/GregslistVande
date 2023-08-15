using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregslistVande.Models
{
	public class House
	{
		public int Id { get; set; }
		public int? Sqft { get; set; }
		public int? Bedrooms { get; set; }
		public double? Bathrooms { get; set; }
		public int? Price { get; set; }
		public string ImgUrl { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}