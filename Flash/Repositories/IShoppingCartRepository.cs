using Flash.Models;

namespace Flash.Repositories
{
	public interface IShoppingCartRepository : IRepsitory<ShoppingCart>
	{
		void Update(ShoppingCart cart);
	}
}
