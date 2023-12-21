using Flash.Data;
using Flash.Models;

namespace Flash.Repositories
{
	// aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context
	public class OrderDetailRepository : Repsitory<OrderDetail>, IOrderDetailRepository
	{
		private  aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;

		public OrderDetailRepository(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db) : base(db)
		{
			_db = db;
		}



		public void Update(OrderDetail orderDetail)
		{
			_db.OrderDetails.Update(orderDetail);
		}
	}
}
