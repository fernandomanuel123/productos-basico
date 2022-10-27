using Dapper;
using Productos.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Productos.Repository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var products = await connection.QueryAsync<Producto>(
                sql: "dbo.GetAll",
                commandType: CommandType.StoredProcedure
                );
            return products;
        }

        public async Task<Producto> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var products = await connection.QueryFirstOrDefaultAsync<Producto>(
                sql: "dbo.GetById",
                param: new { Id = id },
                commandType: CommandType.StoredProcedure);

            return products;
        }

        public async Task<int> Create(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);


            var affectedRows = await connection.ExecuteAsync(
                sql: "dbo.CreateProduct",
                param: new { Nombre = producto.Nombre, Precio = producto.Precio, Stock = producto.Stock, FechaRegistro = producto.FechaRegistro },
                commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

        public async Task<int> Update(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);

            var affectedRows = await connection.ExecuteAsync(
                sql: "dbo.UpdateProduct",
                param: new { Nombre = producto.Nombre, Precio = producto.Precio, Stock = producto.Stock, FechaRegistro = producto.FechaRegistro, Id = producto.Id },
                commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var affectedRows = await connection.ExecuteAsync(
                sql: "dbo.DeleteProduct",
                param: new { Id = id },
                commandType: CommandType.StoredProcedure);

            return affectedRows;
        }
    }
}
