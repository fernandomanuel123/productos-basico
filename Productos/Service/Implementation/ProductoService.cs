using Productos.Entity;
using Productos.Repository.Implementation;

namespace Productos.Service.Implementation
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public Task<int> Create(Producto producto)
        {
            return this.productoRepository.Create(producto);
        }

        public Task<int> Delete(int id)
        {
            return (this.productoRepository.Delete(id));
        }

        public Task<IEnumerable<Producto>> GetAll()
        {
            return productoRepository.GetAll(); 
        }

        public Task<Producto> GetById(int id)
        {
            return productoRepository.GetById(id);
        }

        public Task<int> Update(Producto producto)
        {
            return productoRepository.Update(producto);
        }
    }
}
