namespace ModelCQRS.Models
{
	public class Category
	{
		public Category() {
            Products = new HashSet<Product>();

        }
        public int Id { get; set; }
		public string NameCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

