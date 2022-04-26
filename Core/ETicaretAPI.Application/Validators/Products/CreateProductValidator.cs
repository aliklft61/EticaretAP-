using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Ürün adı 3-100 karakter aralığında olmalıdır");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgilerini boş bırakmayınız")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi 0 dan büyük olmalıdır");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgilerini boş bırakmayınız")
                .Must(s => s >= 0)
                    .WithMessage("Fiyat bilgisi 0 dan büyük olmalıdır");
        }
    }
}
