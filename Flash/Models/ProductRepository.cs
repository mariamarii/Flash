using Flash.Data;
using Flash.Models;
using Flash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Repositories
{
	public class ProductRepository : Repsitory<Product>, IProductRepository
	{
		private readonly aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;
		public ProductRepository(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db) : base(db)
		{
			_db = db;
		}
		public void Update(Product obj)
		{

			//_db.products.Update(obj);
			var objFromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Name = obj.Name;
				objFromDb.Id = obj.Id;
				objFromDb.Price = obj.Price;
				objFromDb.Description = obj.Description;
				objFromDb.CatId = obj.CatId;
				if (obj.ImageUrl != null)
				{
					objFromDb.ImageUrl = obj.ImageUrl;
				}
			}

		}
	}
}
