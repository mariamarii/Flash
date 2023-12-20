using Flash.Models;
using Stripe;

namespace Flash.Repositories
{
	public interface IOrderHeaderRepository : IRepsitory<OrderHeader>
	{
		void Update(OrderHeader orderHeader);
		void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
		void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
		
	}
}
