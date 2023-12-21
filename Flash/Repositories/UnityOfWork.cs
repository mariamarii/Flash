using Flash.Repositories;
using Flash.Models;
using Flash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Repositories
{
	public class UnityOfWork : IUnityOfWork
	{
		public aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;
        public UnityOfWork(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db)
        {
            _db = db;
            OrderDetail = new OrderDetailRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            User = new UserRepository(_db);
            Product = new ProductRepository(_db);
        }
        public IShoppingCartRepository ShoppingCart { get; private set; }
		public IOrderDetailRepository OrderDetail { get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IUserRepository User { get; private set; }
		public IProductRepository Product { get; private set; }

		
		public void Save()
		{
			_db.SaveChanges();
		}

	}
}
