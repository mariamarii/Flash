using Flash.Data;
using Flash.Models;

namespace Flash.Repositories
{
	// aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context
	public class ShoppingCartRepository : Repsitory<ShoppingCart>, IShoppingCartRepository
	{
		private aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;
		public ShoppingCartRepository(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db) : base(db)
		{
			_db = db;
		}

		public void Update(ShoppingCart obj)
		{
			_db.ShoppingCarts.Update(obj);
		}
	}
}
