
using DataAccessLayer.Concrete;
using System;

namespace DataAccessLayer.UnitofWorks
{
	public class UnitofWork(Context context) : IUnitofWork
	{
		public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
		
	}
}
