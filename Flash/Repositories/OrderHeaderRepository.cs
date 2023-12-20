using Flash.Data;
using Flash.Models;

namespace Flash.Repositories
{
	// aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context
	public class OrderHeaderRepository : Repsitory<OrderHeader>, IOrderHeaderRepository
	{
		private readonly aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;

		public OrderHeaderRepository(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader orderHeader)
		{
			_db.OrderHeaders.Update(orderHeader);
		}
		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (orderFromDb != null)
			{
				orderFromDb.OrderStatus = orderStatus;
				if (!string.IsNullOrEmpty(paymentStatus))
				{
					orderFromDb.PaymentStatus = paymentStatus;
				}
			}
		}

		public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
		{
			var orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			orderHeader.PaymentDate = DateTime.Now;
			orderHeader.SessionId = sessionId;
			orderHeader.PaymentIntentId = paymentIntentId;

		}
		//public void PaymentStatus(int id, string sessionId, int paymentIntentId)
		//{
		//	var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
		
		//		orderFromDb.SessionId = sessionId;
			
		//		orderFromDb.PaymentIntentId = paymentIntentId;
		//		orderFromDb.PaymentDate = DateTime.Now;
			
		//}



	}
}
