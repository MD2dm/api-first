using System;
namespace ModelCQRS.requiment
{
	public class ProductRecument
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public byte? Image { get; set; }
        public string Des { get; set; }
        public int CategoryId { get; set; }
    }
}

