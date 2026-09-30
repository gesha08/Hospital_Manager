using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Hospital
{
    public class HospitalDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int BedsCount { get; set; }
        [Display(Name = "Създадена на")]
        public DateTime CreatedOn { get; set; }
    }
}
