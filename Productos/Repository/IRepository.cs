namespace Productos.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
    }
}
