using System.Linq.Expressions;

namespace GameZone.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string[] agers);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
