using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IInfrastructure
{
	public interface IRepository<T>
	{
		void Delete(T entity);
		List<T>? FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
		Task<List<T>?> FindByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
		Task<List<T>?> GetAllAsync();		
		Task<List<T>?> GetAllPagedAsync(int page, int rowPerPage);
		Task<T?> GetAsync(int id);
		Task<T> InsertAsync(T entity);
		Task SaveChangesAsync();
		Task<int> TotalRecords();
		void Update(T entity);
	}
}
