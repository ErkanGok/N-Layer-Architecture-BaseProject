namespace DataAccessLayer.UnitofWorks
{
	public interface IUnitofWork
	{
		Task<int> SaveChangesAsync();
	}
}
