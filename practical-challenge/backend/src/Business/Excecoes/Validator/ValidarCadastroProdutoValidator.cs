using Business.Entidades;
using FluentValidation;

namespace Business.Excecoes.Validator
{
    public class ValidarCadastroProdutoValidator : AbstractValidator<ProdutoInputModel>
    {
        public ValidarCadastroProdutoValidator()
        {
            RuleFor(t => t.Codigo).NotEmpty().NotNull().Length(4, 4)
                .WithMessage("'Codigo' deve conter exatamente 4 caracteres");

            RuleFor(t => t.Descricao).NotEmpty().NotNull()
                .WithMessage("'Descricao' não pode ser null ou vazio.");

            RuleFor(t => t.UnidadeMedida).NotEmpty().NotNull()
                .WithMessage("'UnidadeMedida' não pode ser null ou vazio.");

            RuleFor(t => t.Categoria).NotEmpty().NotNull()
                .WithMessage("'Categoria' não pode ser null ou vazio.");

        }       
    }
}
