using Domain.DTO;
using Domain.Enums;
using FluentValidation;

namespace Domain.Validations
{
    public class ClientServiceValidation : AbstractValidator<Client>
    {
        public ClientServiceValidation()
        {
            RuleFor(x => x.DocumentType).NotNull().NotEmpty().Must(ValidateDocumentType)
                .WithMessage("El valor del campo 'Tipo Documento' no puede ser nulo y debe llevar los siguientes valores: Cedula Ciudadanía (CC), Tarjeta Identidad (TI), Registro Civil (RC).");
            RuleFor(x => x.Document).NotNull().Must(x => MaximumLengthNumber(x, 11)).WithMessage("El numero del nocumento no puede ser nulo ni puede tener una longitud mayor a 11 caracteres.");
            RuleFor(x => x.LastName).NotNull().MaximumLength(30).WithMessage("El valor del campo 'Apellido 1' no puede ser nulo ni tener una longirud mayor a 30 caracteres.");
            RuleFor(x => x.LastName2).MaximumLength(30).WithMessage("El valor del campo 'Apellido 2' no puede tener una longirud mayor a 30 caracteres.");
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(ValidateGender).WithMessage("El valor del campo 'Género' no puede ser nulo y debe contener cualquiera de los siguientes valores: Mujer (F), Hombre (M)");
            RuleFor(x => x.DateOfBirth).Must(BeAValidDate).WithMessage("El valor de del campo 'Fecha de nacimiento' no es valido.");
            RuleFor(x => x.Addresses).Must(ValidateAddresses).WithMessage("El valor ingresado en las direcciones no es correcto");
            RuleFor(x => x.Phones).Must(ValidatePhones).WithMessage("El valor ingresado en los números de telefono no son validos");
            RuleFor(x => x.Email).NotNull().NotEmpty().Must(x => x.BeAValidEmail()).WithMessage("El valor del campo 'Email' no es correcto");
            RuleFor(x => x).NotNull().Must(ValidateDateOfBirthAndDocumentType).WithMessage("La edad del cliente debe de conincidir con el tipo de documento");
        }

        private bool ValidateDateOfBirthAndDocumentType(Client client)
        {
            var yearsOld = (DateTime.Now - client.DateOfBirth).Days / 365;

            switch (client.DocumentType.Replace(" ", "").ToUpper())
            {
                case "RC":
                    return yearsOld <= 7 && yearsOld >= 0;

                case "TI":
                    return yearsOld > 7 && yearsOld <= 17;

                case "CC":
                    return yearsOld > 17;

                default:
                    return false;
            }
        }

        private bool ValidatePhones(List<Phone> list)
             => list.Where(x => string.IsNullOrEmpty(x.PhoneType) || !MaximumLengthNumber(x.PhoneNumber, 10)).Count() == 0;

        private bool ValidateAddresses(List<Address> list)
            => list.Where(x => string.IsNullOrEmpty(x.AddressText) || string.IsNullOrEmpty(x.AddressType)).Count() == 0;

        private bool ValidateGender(string gender)
        {
            try
            {
                Enum.Parse(typeof(GenderEnum), gender.Replace(" ", "").ToUpper());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool MaximumLengthNumber(int number, int maximumLength)
            => Math.Log10(Math.Abs((double)number)) <= maximumLength;

        private bool MaximumLengthNumber(long number, int maximumLength)
            => Math.Log10(Math.Abs((double)number)) <= maximumLength;

        private bool ValidateDocumentType(string documentType)
        {
            try
            {
                Enum.Parse(typeof(DocumentTypeEnum), documentType.Replace(" ", "").ToUpper());
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool BeAValidDate(DateTime date)
            => !date.Equals(default(DateTime));


    }
}
