using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Entities
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Range(1, 5000)]
        public int BedsCount { get; set; }
       public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Doctor> Doctors { get; set; }= new List<Doctor>();
    }
}
