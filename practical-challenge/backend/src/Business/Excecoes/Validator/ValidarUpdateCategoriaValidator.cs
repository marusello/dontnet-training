using Business.Entidades;
using FluentValidation;

namespace Business.Excecoes.Validator
{
    public class ValidarUpdateCategoriaValidator : AbstractValidator<CategoriaInputModel>
    {
        public ValidarUpdateCategoriaValidator()
        {
            RuleFor(t => t.Codigo).NotEmpty().NotNull().Length(4, 4)                 
                 .WithMessage("'Codigo' deve conter exatamente 4 caracteres.");
        }
    }
}
