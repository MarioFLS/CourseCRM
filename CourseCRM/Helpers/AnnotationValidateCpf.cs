using System.ComponentModel.DataAnnotations;

namespace CourseCRM.Helpers
{
    // Validação de CPF https://pt.stackoverflow.com/questions/7910/como-validar-cpf-com-dataannotation-no-cliente-e-servidor
    public class AnnotationValidateCpf : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = ValidateCpf.IsCpf(value.ToString()!);
            return valido;
        }
    }
}
