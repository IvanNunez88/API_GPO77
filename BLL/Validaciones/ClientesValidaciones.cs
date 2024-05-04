using ENTITY;
using ENTITY.DTO;
using FluentValidation;

namespace BLL.Validaciones;

public class ClientesValidaciones : AbstractValidator<CLIENTE>
{

    public ClientesValidaciones()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Revise que el nombre no este vacio")
                              .MinimumLength(2).WithMessage("Revise que el nombre sea mayor a 2 caracteres")
                              .Must(IsValidoTexto).WithMessage("Revise que el nombre este bien escrito");
        RuleFor(x => x.APaterno).NotEmpty().WithMessage("Revise que el apellido paterno no este vacio")
                                .MinimumLength(2).WithMessage("Revise que el apellido parerno sea mayor a 2 caracteres")
                                .Must(IsValidoTexto).WithMessage("Revise que el apellido paterno este bien escrito");
        RuleFor(x => x.AMaterno).NotEmpty().WithMessage("Revise que el apellido materno no este vacio")
                                .MinimumLength(2).WithMessage("Revise que el apellido materno sea mayor a 2 caracteres")
                                .Must(IsValidoTexto).WithMessage("Revise que el apellido materno este bien escrito");
        RuleFor(x => x.RCF).NotEmpty().WithMessage("Revise que el rfc no este vacio")
                           .MinimumLength(12).WithMessage("El rfc debe estar tiene que tene una longitud de 12 o 13 caracteres")
                           .MaximumLength(13).WithMessage("El rfc debe estar tiene que tene una longitud de 12 o 13 caracteres");

    }
    private bool IsValidoTexto(string Texto)
    {
        bool Validacion = true;

        foreach (char letra in Texto.Replace(" ", ""))
        {
            if (!char.IsLetter(letra))
                Validacion = false;
        }
        return Validacion;
    }

}
