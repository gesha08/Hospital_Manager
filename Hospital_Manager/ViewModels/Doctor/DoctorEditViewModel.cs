using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Doctor
{
    public class DoctorEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(30, ErrorMessage = "Името не може да бъде по-дълго от 30 символа.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна.")]
        [MaxLength(30, ErrorMessage = "Фамилията не може да бъде по-дълга от 30 символа.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Специалността е задължителна.")]
        [MaxLength(50, ErrorMessage = "Специалността не може да бъде по-дълга от 50 символа.")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Моля, въведете валиден имейл адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефонният номер е задължителен.")]
        [Phone(ErrorMessage = "Моля, въведете валиден телефонен номер.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Моля, изберете болница.")]
        public int HospitalId { get; set; }
    }
}
