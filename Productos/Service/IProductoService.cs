using Productos.Entity;

namespace Productos.Service
{
    public interface IProductoService : IService<Producto>
    {
        Task<Producto> GetById(int id);
        Task<int> Create(Producto producto);
        Task<int> Update(Producto producto);
        Task<int> Delete(int id);
    }
}
