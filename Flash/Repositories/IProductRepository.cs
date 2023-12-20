
	using Flash.Models;

	namespace Flash.Repositories
	{
		public interface IProductRepository : IRepsitory<Product>
		{

			void Update(Product Product);
		}
	}


