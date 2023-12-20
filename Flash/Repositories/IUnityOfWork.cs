using Flash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flash.Repositories
{
	public interface IUnityOfWork
	{

		IShoppingCartRepository ShoppingCart { get; }
		IOrderDetailRepository OrderDetail { get; }
		IOrderHeaderRepository OrderHeader { get; }
		IUserRepository User { get; }
		IProductRepository Product { get; }
		void Save();
	}
}
