namespace Productos.Service
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
    }
}
