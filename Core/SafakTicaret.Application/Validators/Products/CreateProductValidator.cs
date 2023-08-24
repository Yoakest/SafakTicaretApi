using FluentValidation;
using SafakTicaret.Application.ViewModels.Products;

namespace SafakTicaret.Application.Validators.Products
{
	public class CreateProductValidator : AbstractValidator<VMCreateProduct>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.WithMessage("Lütfen ürün adı giriniz...")
				.NotNull()
				.WithMessage("Lütfen ürün adı giriniz...")
				.MaximumLength(50)
				.WithMessage("Lütfen ürün adını 3 ile 50 karakter arasında giriniz...")
				.MinimumLength(3)
				.WithMessage("Lütfen ürün adını 3 ile 50 karakter arasında giriniz...");

			RuleFor(p => p.Stock)
				.NotEmpty()
				.WithMessage("Lütfen stok bilgisini giriniz...")
				.NotNull()
				.WithMessage("Lütfen stok bilgisini giriniz...")
				.Must(s => int.TryParse(s.ToString(), out _))
				.WithMessage("Stok bilgisi sayı olmalıdır...")
				.Must(s => Convert.ToInt32(s) >= 0)
				.WithMessage("Stok bilgisi negatif olamaz...");

			RuleFor(p => p.Price)
				.NotEmpty()
				.WithMessage("Lütfen fiyat bilgisini giriniz...")
				.NotNull()
				.WithMessage("Lütfen fiyat bilgisini giriniz...")
				.Must(s => float.TryParse(s.ToString(), out _))
				.WithMessage("Fiyat bilgisi sayı olmalıdır...")
				.Must(s => Convert.ToInt32(s) >= 0)
				.WithMessage("Fiyat bilgisi negatif olamaz...");
		}
	}
}
