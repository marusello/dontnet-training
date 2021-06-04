using Business.Entidades;
using FluentValidation;

namespace Business.Excecoes.Validator
{
    public class ValidarCadastroCategoriaValidator : AbstractValidator<CategoriaInputModel>
    {    
        public ValidarCadastroCategoriaValidator()
        {
            RuleFor(t => t.Codigo).NotEmpty().NotNull().Length(4, 4)
                .WithMessage("'Codigo' deve conter exatamente 4 caracteres.");

                RuleFor(t => t.Descricao).NotEmpty().NotNull()
                     .WithMessage("'Descricao' não pode ser null ou vazio.");            
        }
    }
}
