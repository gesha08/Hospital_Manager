using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Patient
{
    public class PatientEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "")]                                                                                                                                                               
        [StringLength(30, ErrorMessage = "Първото име не може да е повече от 30 букви.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "")]
        [StringLength(30, ErrorMessage = "Фамилното име не може да е повече от 30 букви.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Въведи валиден имейл.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Телефонният номер е задължителен.")]
        [Phone(ErrorMessage = "Въведи валиден телефонен номер.")]
        public string PhoneNumber { get; set; }
    }
}
