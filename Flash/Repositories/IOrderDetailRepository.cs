using Flash.Models;

namespace Flash.Repositories
{
	public interface IOrderDetailRepository : IRepsitory<OrderDetail>
	{
		void Update(OrderDetail orderDetail);
	}
}
