using FluentValidation;

namespace Productos.Entity.Validator
{
    public class ProductoValidator : AbstractValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.Nombre).NotNull().NotEmpty();
            RuleFor(producto => producto.Precio).NotNull().NotEmpty().GreaterThan(0).WithMessage("El precio del producto debe de ser mayor a 0");
            RuleFor(producto => producto.Stock).NotNull().GreaterThanOrEqualTo(0).WithMessage("El stock del producto no puede ser negativo");
            RuleFor(producto => producto.FechaRegistro).NotEmpty().NotNull();

        }
    }
}
