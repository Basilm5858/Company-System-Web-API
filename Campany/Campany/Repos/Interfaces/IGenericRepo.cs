namespace Campany.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T item);
        void Delete(T item);
    }
}
