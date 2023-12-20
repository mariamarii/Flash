using Flash.Data;
using Flash.Models;

namespace Flash.Repositories
{
	public class UserRepository : Repsitory<AspNetUser>, IUserRepository
	{
		private readonly aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;
		public UserRepository(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db) : base(db)
		{
			_db = db;

		}
	}
}
