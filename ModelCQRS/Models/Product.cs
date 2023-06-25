using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCQRS.Models
{
	public class Product
	{
		
		public int Id { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public byte? Image { get; set; }
		public string Des { get; set; }

		// Khoá phụ 
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}

