using Microsoft.AspNetCore.Mvc;
using Productos.Entity;
using Productos.Service;

namespace Productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var products = await _productoService.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// Obtiene un producto en específico por su Id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productoService.GetById(id);
            return Ok(products);
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <remarks>
        /// Ejemplo:
        ///     
        ///     {
        ///          "Nombre": "atun",
        ///          "Precio": 15,
        ///          "Stock": 8,
        ///          "FechaRegistro": "2022-09-08T09:21:52.190Z"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Producto product)
        {
            _ = await _productoService.Create(product);
            return Ok();
        }

        /// <summary>
        /// Actualiza un nuevo producto
        /// </summary>
        /// <remarks>
        /// Ejemplo:
        ///     
        ///     {
        ///          "Id: 1"
        ///          "Nombre": "pan",
        ///          "Precio": 2,
        ///          "Stock": 1500,
        ///          "FechaRegistro": "2021-10-05T09:21:52.190Z"
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Producto product)
        {
            var currentProduct = await _productoService.GetById(product.Id);
            if (currentProduct == null)
            {
                return BadRequest("No se ha encontrado producto para actualizar");
            }

            _ = await _productoService.Update(product);
            return Ok();
        }


        /// <summary>
        /// Elimina un producto en específico
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentProduct = await _productoService.GetById(id);
            if (currentProduct == null)
            {
                return BadRequest("No se ha encontrado producto a eliminar");
            }

            _ = await _productoService.Delete(id);
            return Ok();
        }
    }
}